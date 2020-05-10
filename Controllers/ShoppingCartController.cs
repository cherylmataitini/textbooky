using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TextBooky.Models;
using TextBooky.ViewModels;

namespace TextBooky.Controllers
{
    public class ShoppingCartController : Controller
    {
        // have to work with TextBooks as well as the cart itself - so need repository of the TextBooks & the ShoppingCart object
        private readonly ITextBookRepository _textBookRepository;
        private readonly ShoppingCart _shoppingCart;

        // inject into constructor
        public ShoppingCartController(ITextBookRepository textBookRepository, ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
            _textBookRepository = textBookRepository;
        }

        public ViewResult Index()
        {
            // to get total amounts and Items etc.
            _shoppingCart.shoppingCartItems = _shoppingCart.GetShoppingCartItems();

            // combine items & total amount into a ViewModel
            // ViewModel will have 2 props - ShoppingCart & ShoppingCartTotal
            var ShoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(ShoppingCartViewModel);
        }


        public RedirectToActionResult AddToShoppingCart(int textbookId)
        {
            var selectedTextbook = _textBookRepository.GetAllTextbooks.FirstOrDefault(t => t.Id == textbookId);

            // if Textbook exists - add to shopping cart
            if (selectedTextbook != null)
            {
                _shoppingCart.AddToCart(selectedTextbook, 1);
            }

            return RedirectToAction("Index"); // bc its on this controller don't need to specify controller
        }


        public RedirectToActionResult RemoveFromShoppingCart(int textbookId)
        {
            var selectedTextbook = _textBookRepository.GetAllTextbooks.FirstOrDefault(t => t.Id == textbookId);

            // if Textbook exists - remove from shopping cart
            if (selectedTextbook != null)
            {
                _shoppingCart.RemoveFromCart(selectedTextbook);
            }

            return RedirectToAction("Index"); // bc its on this controller don't need to specify controller
        }

    }   
}
