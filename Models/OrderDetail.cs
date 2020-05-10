using System;
namespace TextBooky.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int TextBookId { get; set; }
        public TextBook Textbook { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Order Order { get; set; } // creates relationship - one to many
    }
}
