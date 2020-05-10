using System;
using System.Collections;
using System.Collections.Generic;
using TextBooky.Models;

namespace TextBooky.ViewModels
{
    public class TextBookListViewModel
    {
        // display each of the textbooks as well as the current category

        // properties
        public IEnumerable<TextBook> Textbooks { get; set; }
        public string CurrentCategory { get; set; }
    }
}
