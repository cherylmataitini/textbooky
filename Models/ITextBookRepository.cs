using System;
using System.Collections.Generic;
using System.Linq;

namespace TextBooky.Models
{
    public interface ITextBookRepository
    {
        IEnumerable<TextBook> GetAllTextbooks { get; }
        TextBook GetTextBookById(int id);
        TextBook GetTextBookByISBN(string isbn);
    }
}
 