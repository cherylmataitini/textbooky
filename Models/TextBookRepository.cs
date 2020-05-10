using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TextBooky.Models
{
    public class TextBookRepository : ITextBookRepository
    {
        // bringing in DbContext
        private readonly AppDbContext _appDbContext;

        // to use DbContext - inject into constructor
        public TextBookRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<TextBook> GetAllTextbooks
        {
            get
            {
                // return all Textbooks and category for each
                return _appDbContext.TextBooks.Include(c => c.Category);  
            }
        }

        public TextBook GetTextBookById(int id)
        {
            return _appDbContext.TextBooks.FirstOrDefault(t => t.Id == id);
        }

        public TextBook GetTextBookByISBN(string isbn)
        {
            return _appDbContext.TextBooks.FirstOrDefault(t => t.ISBN.Equals(isbn));
        }
    }
}

//public int Id { get; set; }
//public string Title { get; set; }
//public string Author { get; set; }
//public string Description { get; set; }
//public string ISBN { get; set; }
//public string ImageUrl { get; set; }
//public decimal Price { get; set; }
//public decimal PriceMonthly { get; set; }
//public bool InStock { get; set; }
//public Category Category { get; set; }
//public int CategoryId { get; set; } -- not in here but we have Category property in each TextBook, which includes the CategoryId