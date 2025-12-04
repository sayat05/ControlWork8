using Library_Mvc.Interfaces;
using Library_Mvc.Models.DtoModels;
using Microsoft.AspNetCore.Mvc;

namespace Library_Mvc.Controllers;

public class UsersController(IUserRepository users) : Controller
{
    public async Task<IActionResult> Index(string email)
    {
        var user = await users.GetByEmailAsync(email);
        return View(user);
    }

    [HttpGet]
    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(UserCreateDto dto)
    {
        if (!ModelState.IsValid)
            return View(dto);

        await users.CreateAsync(dto);
        return RedirectToAction("Index");
    }
}