using Library_Mvc.Models;

namespace Library_Mvc.Interfaces;

public interface IBookRepository
{
    // Репозиторий должен уметь работать с бд,
    // выполнение всех CRUD операций

    Task<IEnumerable<Book>> GetAll();
    Task<Book?> GetById(long id);
    Task<int> Add(Book book);
    Task<StatusBook> Update(StatusBook book);
    Task Delete(long id);
}