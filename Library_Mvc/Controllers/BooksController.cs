using Library_Mvc.Interfaces;
using Library_Mvc.Models.DtoModels;
using Microsoft.AspNetCore.Mvc;

namespace Library_Mvc.Controllers;

public class BooksController(IBookService bookService) : Controller
{
    [HttpGet]
    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(BookAddDto model)
    {
        if (!ModelState.IsValid) return View(model);
        await bookService.AddBookAsync(model);
        return RedirectToAction("Index", "Home");
    }
    
    [HttpGet]
    public async Task<IActionResult> Details(long id)
    {
        var book = await bookService.GetBookByIdAsync(id);
        if (book == null) return NotFound();
        return View(book);
    }
}