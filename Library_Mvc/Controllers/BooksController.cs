using Library_Mvc.Interfaces;
using Library_Mvc.Models.DtoModels;
using Microsoft.AspNetCore.Mvc;

namespace Library_Mvc.Controllers;

public class BooksController(IBookRepository bookRepository) : Controller
{
    public async Task<IActionResult> Index()
    {
        var books = await bookRepository.GetAllAsync();
        return View(books);
    }

    public async Task<IActionResult> Details(long id)
    {
        var book = await bookRepository.GetByIdAsync(id);
        return View(book);
    }

    [HttpGet]
    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(BookCreateDto dto)
    {
        if (!ModelState.IsValid) return View(dto);

        await bookRepository.CreateAsync(dto);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(long id)
    {
        var book = await bookRepository.GetByIdAsync(id);
        if (book == null) return NotFound();

        var dto = new BookCreateDto
        {
            Name = book.Name,
            Author = book.Author,
            RefImg = book.RefImg,
            CategoryId = book.CategoryId
        };

        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(long id, BookCreateDto dto)
    {
        if (!ModelState.IsValid) return View(dto);

        await bookRepository.UpdateAsync(id, dto);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(long id)
    {
        await bookRepository.DeleteAsync(id);
        return RedirectToAction("Index");
    }
}