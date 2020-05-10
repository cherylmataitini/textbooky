using System;
using System.Collections.Generic;

namespace TextBooky.Models
{
    public class CategoryRepository : ICategoryRepository //implements this repository/interface
    {
        // bring in DbContext
        private readonly AppDbContext _appDbContext;

        // inject into constructor
        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public IEnumerable<Category> GetAllCategories => _appDbContext.Categories;
        // returns all categories and assigns to property GetAllCategories
    }
}

//new Category{CategoryId=1, CategoryName="Life Sciences"},
// new Category{CategoryId=2, CategoryName="Physical Sciences"},
// new Category{CategoryId=3, CategoryName="Computer Science"}
