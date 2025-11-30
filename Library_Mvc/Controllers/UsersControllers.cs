using Library_Mvc.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library_Mvc.Controllers;

public class UsersController(IBookService bookService) : Controller
{
    public async Task<IActionResult> Profile()
    {
        var allBooks = await bookService.GetAllBooksAsync();
        var userBooks = allBooks.Take(3); 
        return View(userBooks);
    }

    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    public IActionResult Register(Library_Mvc.Models.User model)
    {
        // TODO: регистрация пользователя и добавление в library_users
        return RedirectToAction("Profile");
    }
}