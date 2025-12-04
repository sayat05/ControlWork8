using System.Data;
using Dapper;
using Library_Mvc.Interfaces;
using Library_Mvc.Models.DtoModels;

namespace Library_Mvc.Repositories;

public class BorrowedBookRepository(IDbConnection connection) : IBorrowedBookRepository
{
    public async Task<bool> IsUserHasLimitAsync(long userId)
    {
        var sql = """
                  select count(*) 
                  from borrowed_books 
                  where user_id = @userId and date_returned is null;
                  """;
        var count = await connection.ExecuteScalarAsync<int>(sql, new { userId });
        return count >= 3;
    }

    public async Task<bool> IsBookBorrowedAsync(long bookId)
    {
        var sql = """
                  select count(*) 
                  from borrowed_books 
                  where book_id = @bookId and date_returned is null;
                  """;
        var count = await connection.ExecuteScalarAsync<int>(sql, new { bookId });
        return count > 0;
    }

    public async Task BorrowAsync(long userId, long bookId)
    {
        var sql = """
                  insert into borrowed_books (user_id, book_id)
                  values (@userId, @bookId);
                  """;
        await connection.ExecuteAsync(sql, new { userId, bookId });
    }

    public async Task ReturnAsync(long borrowId)
    {
        var sql = """
                  update borrowed_books set date_returned = current_timestamp
                  where id = @borrowId
                  """;
        await connection.ExecuteAsync(sql, new { borrowId });
    }

    public async Task<IEnumerable<BorrowedBookDto>> GetAllAsync()
    {
        var sql = """
                  select
                      bb.id as borrowId,
                      b.name as BorrowName,
                      b.author,
                      u.first_name || ' ' || u.last_name as userFullName,
                      bb.date_taken as dateTaken
                  from borrowed_books bb 
                  join books b on bb.book_id = b.id
                  join users u on bb.user_id = u.id
                  where bb.date_returned is null
                  """;
        return await connection.QueryAsync<BorrowedBookDto>(sql);
    }

    public async Task<IEnumerable<BookCardDto>> GetUserBorrowedBooksAsync(long userId)
    {
        var sql = """
                  select 
                      b.id,
                      b.name,
                      b.author,
                      b.ref_img as ref_img,
                      'Выдана' as status
                  from borrowed_books bb 
                  join books b on bb.book_id = b.id
                  where bb.user_id = @userId and bb.date_returned is null;
                  """;
        return await connection.QueryAsync<BookCardDto>(sql, new { userId });
    }
}