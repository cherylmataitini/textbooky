using System;
using Microsoft.AspNetCore.Mvc;
using TextBooky.Models;
using TextBooky.ViewModels;

namespace TextBooky.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        // displaying number of items in the shopping cart
        private readonly ShoppingCart _shoppingCart; // same instance that we created in Startup class - that calls GetCart

        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }  

        // invoked by MVC when the view component is placed inside a view
        public IViewComponentResult Invoke()
        {
            _shoppingCart.shoppingCartItems = _shoppingCart.GetShoppingCartItems();

            var shoppingCartViewModel = new ShoppingCartViewModel()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel); // return type is IViewComponentResult
        }
    }
}
