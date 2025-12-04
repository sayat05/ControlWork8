using Library_Mvc.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library_Mvc.Controllers;

public class AccountController(
    IUserRepository userRepository,
    IBorrowedBookRepository borrowRepository)
    : Controller
{
    [HttpGet]
    public IActionResult Index() => View();

    [HttpPost]
    public async Task<IActionResult> Index(string email)
    {
        var user = await userRepository.GetByEmailAsync(email);
        if (user == null)
        {
            TempData["Error"] = "Пользователь не найден";
            return View();
        }

        var books = await borrowRepository.GetUserBorrowedBooksAsync(user.Id);

        return View("Cabinet", books);
    }
}