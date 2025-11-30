using System.Data;
using Dapper;
using Library_Mvc.Interfaces;
using Library_Mvc.Models;

namespace Library_Mvc.Repositories;

public class StatusBookRepository(IDbConnection connection) : IStatusBookRepository
{
    public Task<IEnumerable<StatusBook>> GetAll()
    {
        var sql = """
                  select 
                      id,
                      book_id as BookId,
                      status
                  from statuses_books 
                  """;
        return connection.QueryAsync<StatusBook>(sql);
    }

    public Task<StatusBook?> GetById(long id)
    {
        var sql = """
                   
                  select 
                      book_id as BookId, 
                      status
                  from statuses_books 
                  where id = @id;

                  """;
        return connection.QueryFirstOrDefaultAsync<StatusBook>(sql, new { id });
    }

    public Task Add(StatusBook statusBook)
    {
        var sql = """
                  insert into statuses_books(book_id, status)
                  values (@book_id, @status)
                  """;
        return connection.ExecuteAsync(sql, new
        {
            statusBook.BookId,
            statusBook.Status
        });
    }

    public Task Update(StatusBook statusBook)
    {
        var sql = """
                  update statuses_books set
                  status = @status
                  where id = @id
                  """;
        return connection.QuerySingleAsync<StatusBook>(sql, new
        {
            statusBook.Status
        });

    }

    public Task Delete(long id)
    {
        const string sql = "delete from statuses_books where id = @id";
        return connection.ExecuteAsync(sql, new { id });
    }
}