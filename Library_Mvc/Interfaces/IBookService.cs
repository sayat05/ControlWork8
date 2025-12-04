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

    Task<IEnumerable<BookCardDto>> GetAllBooks();
    Task<BookDetailDto?> GetBookById(long id);
    Task<long> CreateBook(BookCreateDto bookCreateDto);
    Task UpdateBook(long id, BookCreateDto bookCreateDto);
    Task DeleteBook(long id);
}