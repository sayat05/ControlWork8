using Library_Mvc.Interfaces;
using Library_Mvc.Models.DtoModels;

namespace Library_Mvc.Services;

public class BookService(IBookRepository bookRepository) : IBookService
{
    public Task<IEnumerable<BookCardDto>> GetAllBooks()
    {
        return bookRepository.GetAllAsync();
    }

    public Task<BookDetailDto?> GetBookById(long id)
    {
        return bookRepository.GetByIdAsync(id);
    }

    public Task<long> CreateBook(BookCreateDto bookCreateDto)
    {
        return bookRepository.CreateAsync(bookCreateDto);
    }

    public Task UpdateBook(long id, BookCreateDto bookCreateDto)
    {
        return bookRepository.UpdateAsync(id, bookCreateDto);
    }

    public Task DeleteBook(long id)
    {
        return bookRepository.DeleteAsync(id);
    }
}