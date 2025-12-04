using Library_Mvc.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library_Mvc.Controllers;

public class BorrowedBooksController(
    IBorrowedBookRepository borrowRepository,
    IUserRepository userRepository,
    IBookRepository bookRepository)
    : Controller
{
    [HttpPost]
    public async Task<IActionResult> Borrow(long bookId, string email)
    {
        var user = await userRepository.GetByEmailAsync(email);
        if (user == null)
        {
            TempData["Error"] = "Пользователь не найден";
            return RedirectToAction("Details", "Books", new { id = bookId });
        }

        if (await borrowRepository.IsUserHasLimitAsync(user.Id))
        {
            TempData["Error"] = "Нельзя брать более 3-х книг!";
            return RedirectToAction("Details", "Books", new { id = bookId });
        }

        if (await borrowRepository.IsBookBorrowedAsync(bookId))
        {
            TempData["Error"] = "Книга уже выдана!";
            return RedirectToAction("Details", "Books", new { id = bookId });
        }

        await borrowRepository.BorrowAsync(user.Id, bookId);

        return RedirectToAction("Index", "Books");
    }

    public async Task<IActionResult> Return(long borrowId)
    {
        await borrowRepository.ReturnAsync(borrowId);

        return RedirectToAction("AllIssued");
    }

    public async Task<IActionResult> AllIssued()
    {
        var list = await borrowRepository.GetAllAsync();
        return View(list);
    }
}