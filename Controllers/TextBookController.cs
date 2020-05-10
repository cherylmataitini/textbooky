using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TextBooky.Models;
using TextBooky.ViewModels;


namespace TextBooky.Controllers
{
    public class TextBookController : Controller
    {
        // readonly field for interfaces to have access to the data from repositories/classes
        private readonly ITextBookRepository _textBookReposistory;
        private readonly ICategoryRepository _categoryRepository;

        // constructor
        public TextBookController(ITextBookRepository textBookRepository, ICategoryRepository categoryRepository)
        {
            _textBookReposistory = textBookRepository;
            _categoryRepository = categoryRepository;
        }

        // GET: /<controller>/

        public ViewResult List(string category) 
        {
            IEnumerable<TextBook> textbooks;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                textbooks = _textBookReposistory.GetAllTextbooks.OrderBy(t => t.Category.CategoryName);
                currentCategory = "All Textbooks";
            }
            else
            {
                textbooks = _textBookReposistory.GetAllTextbooks.Where(t => t.Category.CategoryName == category);
                currentCategory = _categoryRepository.GetAllCategories.FirstOrDefault(t => t.CategoryName == category)?.CategoryName; // null check
            }

            return View(new TextBookListViewModel
            {
                Textbooks = textbooks,
                CurrentCategory = currentCategory
            });
        }
         
        public IActionResult Details(int id)
        {
            var textbook = _textBookReposistory.GetTextBookById(id);
            if (textbook == null) return NotFound(); // 404

            return View(textbook);
        }
            
    }
}
