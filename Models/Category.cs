using System;
using System.Collections.Generic;

namespace TextBooky.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<TextBook> TextBooks { get; set; } // list of books in a category
    }
}
