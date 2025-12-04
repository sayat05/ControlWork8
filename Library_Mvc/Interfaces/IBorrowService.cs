using Library_Mvc.Models.DtoModels;

namespace Library_Mvc.Interfaces;

public interface IBorrowService
{
    Task Borrow(BorrowRequestDto dto);
    Task Return(long borrowId);
    Task<IEnumerable<BookCardDto>> GetUserBooks(long userId);
    Task<IEnumerable<BorrowedBookDto>> GetAllBorrowed();
}