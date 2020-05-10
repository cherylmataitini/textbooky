using System;

namespace TextBooky.Models
{
    public class TextBook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public bool InStock { get; set; } 
        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public decimal CalculatePriceMonthly(decimal price)
        {
            return Math.Round(price / 12, 2);
        }
    }
}
