using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TextBooky.Models;


namespace TextBooky.Components
{
    public class CategoryMenu : ViewComponent
    {
        // working with categories, so bringing in the Category repository
        private readonly ICategoryRepository _categoryRepository;

        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

    public IViewComponentResult Invoke()
    {
        var categories = _categoryRepository.GetAllCategories.OrderBy(c => c.CategoryName);

        return View(categories);
    }
    }
}
