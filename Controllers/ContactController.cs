using System;
using Microsoft.AspNetCore.Mvc;

namespace TextBooky.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
