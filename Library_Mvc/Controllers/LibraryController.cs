using Library_Mvc.Models.DtoModels;
using Library_Mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library_Mvc.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LibraryController(BookService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookCardDto>>> GetAllAsync()
    {
        return Ok(await service.GetAllBooksAsync());
    }

    [HttpGet]
    public async Task<ActionResult<BookDetailDto>> GetByIdAsync(long id)
    {
        return Ok(await service.GetBookByIdAsync(id));
    }

    [HttpPost]
    public async Task<ActionResult<BookStatusDto>> AddAsync([FromBody] BookAddDto bookAddDto)
    {
        return Ok(await service.AddBookAsync(bookAddDto));
    }

    [HttpPut]
    public async Task<ActionResult<BookStatusDto>> IssuedBookAsync(long id)
    {
        return Ok(await service.IssuedBook(id));
    }
    
    [HttpPut]
    public async Task<ActionResult<BookStatusDto>> ReturnBookAsync(long id)
    {
        return Ok(await service.ReturnBookAsync(id));
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteAsync(long id)
    {
        await service.Delete(id);
        return NoContent();
    }


}