using System;
using System.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TextBooky.Models;
using Stripe;
using Stripe.Checkout;
using System.Collections.Generic;
using Microsoft.Extensions.Options;

namespace TextBooky.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;
        private readonly StripeConfig _config;


        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart, StripeConfig config)
        {
            _shoppingCart = shoppingCart;
            _orderRepository = orderRepository;
            _config = config;
        }


        // GET Checkout
        public IActionResult Checkout()
        { 
            return View();
        }


        [HttpPost]
        // method to process the order
        public IActionResult Checkout(Models.Order order)
        {
            // model binding binds the html inputs to the corresponding properties of the Order
            _shoppingCart.shoppingCartItems = _shoppingCart.GetShoppingCartItems();

            if (_shoppingCart.shoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty");
            }

            if (ModelState.IsValid) // all the data is bound correctly
            {
                // create order, clear cart & display view 
                _orderRepository.CreateOrder(order);
                //_shoppingCart.ClearCart();
                
                return RedirectToAction("Charge");//CheckoutComplete
            }

            // if order not valid - re display order in same view
            return View(order); 
        }


        public IActionResult Charge()
        {
            //Models.Order order = _orderRepository.getOrder(orderId);
            _shoppingCart.shoppingCartItems = _shoppingCart.GetShoppingCartItems();
            decimal shoppingCartTotal = _shoppingCart.GetShoppingCartTotal();
            StripeConfiguration.ApiKey = _config.SecretKey;

            List<SessionLineItemOptions> SessionLineItemOptionsList = new List<SessionLineItemOptions>();
            foreach (var item in _shoppingCart.shoppingCartItems)
            {
                SessionLineItemOptionsList.Add(new SessionLineItemOptions
                {
                    Name = item.Textbook.Title,
                    Description = item.Textbook.Title,
                    Amount = Decimal.ToInt32(item.Textbook.Price) * 100,
                    Currency = "gbp",
                    Quantity = item.Quantity,

                });
            }

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> {
                    "card",
                },
                LineItems = SessionLineItemOptionsList,
                SuccessUrl = "https://textbooky.azurewebsites.net/Order/CheckoutComplete",
                CancelUrl = "https://textbooky.azurewebsites.net/Order/Checkout",
            };
            //https://localhost:5001/Order/CheckoutComplete
            var service = new SessionService();
            Session session = service.Create(options);

            ViewBag.sessionId = session.Id;
            ViewBag.stripePublishableKey = _config.PublishableKey.ToString();

            ViewBag.shoppingCartTotal = shoppingCartTotal;
            return View(); // passing in the order to display user order details 
        }


        public IActionResult CheckoutComplete()
        {
            _shoppingCart.ClearCart();

            ViewBag.CheckoutCompleteMessage = "Thank you for your order.";
            return View();
        }
    }
}

