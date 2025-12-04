using Library_Mvc.Models;
using Library_Mvc.Models.DtoModels;

namespace Library_Mvc.Interfaces;

public interface IBorrowedBookRepository
{
    Task<bool> IsUserHasLimit(long userId);
    Task<bool> IsBookBorrowed(long bookId);
    Task Borrow(long userId, long bookId);
    Task Return(long borrowId);
    Task<IEnumerable<BorrowedBook>> GetAll();
    Task<IEnumerable<BookCardDto>> GetUserBorrowedBooks(long userId);
}