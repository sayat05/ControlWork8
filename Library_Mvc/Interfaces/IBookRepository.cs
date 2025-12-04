using Library_Mvc.Models.DtoModels;

namespace Library_Mvc.Interfaces;

public interface IBookRepository
{
    // Репозиторий должен уметь работать с бд,
    // выполнение всех CRUD операций

    Task<IEnumerable<BookCardDto>> GetAllAsync();
    Task<BookDetailDto?> GetByIdAsync(long id);
    Task<long> CreateAsync(BookCreateDto bookCreateDto);
    Task UpdateAsync(long id, BookCreateDto bookCreateDto);
    Task DeleteAsync(long id);
}