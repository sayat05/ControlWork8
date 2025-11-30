using Library_Mvc.Interfaces;
using Library_Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_Mvc.Controllers;

public class CategoriesController(ICategoryRepositories categoryRepository) : Controller
{
    [HttpGet]
    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Category model)
    {
        if (!ModelState.IsValid) return View(model);
        await categoryRepository.Add(model);
        return RedirectToAction("Index", "Home");
    }
}