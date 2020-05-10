using System;
using TextBooky.Models;

namespace TextBooky.ViewModels
{
    public class HomeViewModel
    {
        public IEquatable<TextBook> TextBooks { get; set; }
    }
}
