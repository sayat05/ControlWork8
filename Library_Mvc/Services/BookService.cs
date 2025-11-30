using Library_Mvc.Enum;
using Library_Mvc.Interfaces;
using Library_Mvc.Models;
using Library_Mvc.Models.DtoModels;
using Library_Mvc.PatternState.ContextModel;

namespace Library_Mvc.Services;

public class BookService(IBookRepository bookRepository, ICategoryRepositories categoryRepository, IStatusBookRepository statusBookRepository) : IBookService
{
    public async Task<IEnumerable<BookStatusDto>> GetAllBooksAsync()
    {
        var books = await bookRepository.GetAll();
        var statusBooks1 = (await statusBookRepository.GetAll()).ToDictionary(s => s.BookId, s => s.Status);
        return books.Select(b => new BookStatusDto
        {
            Author = b.Author,
            Name = b.Name,
            RefImg = b.RefImg,
            Status = statusBooks1.TryGetValue(b.Id, out var s) ? s.ToString() : "Не найдено"
        }).ToList();
    }

    public async Task<BookDetailDto?> GetBookByIdAsync(long id)
    {
        var book = await bookRepository.GetById(id);
        if (book == null)
            throw new Exception("Книга не найдена");
        var category = await categoryRepository.GetById(book.Id);
        var status = await statusBookRepository.GetById(book.Id);
        var bookDetailDto = new BookDetailDto
        {
            Id = book.Id,
            Name = book.Name,
            Author = book.Author,
            RefImg = book.RefImg,
            Description = book.Description,
            CreateDate = book.CreateDate,
            CategoryId = book.CategoryId,
            CategoryName = category?.Name ?? "Неизвестная категория",
            StatusStr = status.Status.ToString(),
            StatusInt = status.Status,
            DateAdded = book.DateAdded,
        };

        return bookDetailDto;
    }

    public async Task<BookStatusDto> AddBookAsync(BookAddDto bookAddDto)
    {
        var category = await categoryRepository.GetByName(bookAddDto.CategoryName);

        if (category == null)
            throw new Exception("Категория не найдена");
        
        var book = new Book
        {
            Name = bookAddDto.Name,
            Author = bookAddDto.Author,
            RefImg = bookAddDto.RefImg,
            CreateDate = bookAddDto.CreateDate,
            Description = bookAddDto.Description,
            CategoryId = category.Id,
            DateAdded = DateTime.Now
        };
        
        var id = await bookRepository.Add(book);
        var statusBook = new StatusBook
        {
            BookId = id,
            Status = Statuses.InStock
        };

        await statusBookRepository.Add(statusBook);
        
        return new BookStatusDto
        {
            Name = book.Name,
            Author = book.Name,
            RefImg = book.RefImg,
            Status = "InStock"
        };
    }

    public async Task<BookStatusDto> IssuedBook(long id)
    {
        var book = await bookRepository.GetById(id);
        if (book == null)
            throw new Exception("Книга не найдена");
        
        var status = await statusBookRepository.GetById(id);
        var context = new BookContext(status);
        context.Issued();
        await statusBookRepository.Update(context.CurrentBook);
        return new BookStatusDto
        {
            Author = book.Author,
            Name = book.Name,
            RefImg = book.RefImg,
            Status = context.CurrentBook.Status.ToString()
        };
    }

    public async Task<BookStatusDto> ReturnBookAsync(long id)
    {
        var book = await bookRepository.GetById(id);
        if (book == null)
            throw new Exception("Книга не найдена");

        var status = await statusBookRepository.GetById(id);
        
        var context = new BookContext(status);
        context.Issued();
        return new BookStatusDto
        {
            Author = book.Author,
            Name = book.Name,
            RefImg = book.RefImg,
            Status = context.CurrentBook.Status.ToString()
        };
    }

    public async Task Delete(long id) => 
        await bookRepository.Delete(id);
}