using Library_Mvc.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library_Mvc.Controllers;

public class HomeController(IBookService bookService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var books = await bookService.GetAllBooksAsync();
        return View(books);
    }
}