using Library_Mvc.Models.DtoModels;

namespace Library_Mvc.Interfaces;

public interface IBookService
{
    /*
     Сервис должен уметь:
     1 - показывать все книги,
     2 - показывать книгу по id,
     3 - добавлять книгу,
     4 - получать книгу, 
     5 - менять статус при выдаче и сдаче книги:
         a - выдать книгу,
         b - сдать книгу
    */

    Task<IEnumerable<BookCardDto>> GetAllBooksAsync();
    Task<BookDetailDto?> GetBookByIdAsync(long id);
    Task<BookStatusDto> AddBookAsync(BookAddDto bookAddDto);
    Task<BookStatusDto> IssuedBook(long id);
    Task<BookStatusDto> ReturnBookAsync(long id);
    Task Delete(long id);
}