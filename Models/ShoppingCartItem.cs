using System;
namespace TextBooky.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public string ShoppingCartId { get; set; }
        public TextBook Textbook { get; set; }
        public int Quantity { get; set; } 
    }
}
