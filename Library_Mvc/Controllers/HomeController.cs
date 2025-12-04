using Library_Mvc.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library_Mvc.Controllers
{
    public class HomeController(IBookRepository bookRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var books = await bookRepository.GetAllAsync(); 
            return View(books);
        }
    }
}