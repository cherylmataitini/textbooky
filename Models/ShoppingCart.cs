using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TextBooky.Models
{
    public class ShoppingCart
    {
        private readonly AppDbContext _appDbContext;
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> shoppingCartItems { get; set; }


        public ShoppingCart(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            // creating session
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            // get current DbContext from the service using GetService()
            var context = services.GetService<AppDbContext>();
            string shoppingCartId = session.GetString("ShoppingCartId") ?? Guid.NewGuid().ToString(); // create session if not there

            // set session
            session.SetString("ShoppingCartId", shoppingCartId);
                
            // return shopping cart
            return new ShoppingCart(context)
            {
                ShoppingCartId = shoppingCartId
            };
        }


        public void AddToCart(TextBook textBook, int quantity)
        {
            // check if shopping cart exists & if textbook with id exists
            var shoppingCartItem = _appDbContext.ShoppingCartItems.SingleOrDefault(s => s.Textbook.Id == textBook.Id && s.ShoppingCartId == ShoppingCartId); // bc would be set in GetCart()

            if (shoppingCartItem == null)
            {
                // item doesn't exist in cart yet so create instance
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId, // from this class
                    Textbook = textBook,
                    Quantity = quantity
                };
                // add cart to dataset
                _appDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                // cart already exists - just increase quantity
                shoppingCartItem.Quantity++;
            }
            _appDbContext.SaveChanges();
        }


        public int RemoveFromCart(TextBook textBook) 
        {
            var shoppingCartItem = _appDbContext.ShoppingCartItems.SingleOrDefault(s => s.Textbook.Id == textBook.Id && s.ShoppingCartId == ShoppingCartId);

            // counter used to dec qty in shoppingcart - will be the int returned from this method
            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Quantity > 1)
                {
                    shoppingCartItem.Quantity--;
                    localAmount = shoppingCartItem.Quantity;
                }
                else // only 1 of this textbook id - delete completely
                {
                    _appDbContext.ShoppingCartItems.Remove(shoppingCartItem);

                }
            }

            _appDbContext.SaveChanges();
            return localAmount; // new qty of that textbook in the cart
        }


        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            // find corresponding shopping cart items, return all the textbooks that belong to this ShoppingCartId, return list
            return shoppingCartItems ?? (shoppingCartItems = _appDbContext.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId)
                .Include(s => s.Textbook)
                .ToList());
        }


        public void ClearCart()
        {
            // get all items from DbContext that belong to this ShoppingCartId
            var cartItems = _appDbContext.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId);

            _appDbContext.ShoppingCartItems.RemoveRange(cartItems); // takes cartItems that we just retrieved

            _appDbContext.SaveChanges();
        }


        public decimal GetShoppingCartTotal()
        {
            // retrieve items
            var total = _appDbContext.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId)
                .Select(s => s.Textbook.Price * s.Quantity).Sum();

          //  total = Math.Truncate(100 * total) / 100;
            return Math.Round(total,2);
        }
    }  
}
