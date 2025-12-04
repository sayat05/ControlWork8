using Library_Mvc.Interfaces;
using Library_Mvc.Models.DtoModels;

namespace Library_Mvc.Services;

public class BorrowService(IUserRepository userRepository, IBorrowedBookRepository borrowedRepository, IBookRepository bookRepository) : IBorrowService
{
    public async Task Borrow(BorrowRequestDto dto)
    {
        var user = await userRepository.GetByEmailAsync(dto.UserEmail);
        if (user == null)
            throw new Exception("Пользователь не найден");

        if (await borrowedRepository.IsUserHasLimitAsync(user.Id))
            throw new Exception("Пользователь уже взял 3 книги");
        
        if (await borrowedRepository.IsBookBorrowedAsync(dto.BookId))
            throw new Exception("Книга уже выдана");

        await borrowedRepository.BorrowAsync(user.Id, dto.BookId);
    }

    public async Task Return(long borrowId)
    { 
        await borrowedRepository.ReturnAsync(borrowId);
    }

    public Task<IEnumerable<BookCardDto>> GetUserBooks(long userId)
    {
        return borrowedRepository.GetUserBorrowedBooksAsync(userId);
    }

    public Task<IEnumerable<BorrowedBookDto>> GetAllBorrowed()
    {
        return borrowedRepository.GetAllAsync();
    }
}