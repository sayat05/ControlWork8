using Library_Mvc.Models.DtoModels;

namespace Library_Mvc.Interfaces;

public interface IBorrowedBookRepository
{
    Task<bool> IsUserHasLimitAsync(long userId);
    Task<bool> IsBookBorrowedAsync(long bookId);
    Task BorrowAsync(long userId, long bookId);
    Task ReturnAsync(long borrowId);
    Task<IEnumerable<BorrowedBookDto>> GetAllAsync();
    Task<IEnumerable<BookCardDto>> GetUserBorrowedBooksAsync(long userId);
}