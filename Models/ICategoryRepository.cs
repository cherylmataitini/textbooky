using System;
using System.Collections.Generic;

namespace TextBooky.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories { get; }
    }
}
 