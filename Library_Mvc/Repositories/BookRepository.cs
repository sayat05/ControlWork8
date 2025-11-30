using System.Data;
using Dapper;
using Library_Mvc.Interfaces;
using Library_Mvc.Models;

namespace Library_Mvc.Repositories;

public class BookRepository(IDbConnection connection) : IBookRepository
{
    public Task<IEnumerable<Book>> GetAll()
    {
        var sql = """
                  select 
                      b.id, 
                      b.name, 
                      b.author, 
                      b.ref_img as refImg, 
                      b.create_date as createDate, 
                      b.description,   
                      b.date_added as dateAdded, 
                      b.category_id as categoryId
                  from books as b
                  left join categories as c on b.category_id = c.id;
                  """;
        return connection.QueryAsync<Book>(sql);
    }

    public Task<Book?> GetById(long id)
    {
        var sql = """
                   select 
                       b.id, 
                       b.name, 
                       b.author, 
                       b.ref_img as refImg, 
                       b.create_date as createDate, 
                       b.description,   
                       b.date_added as dateAdded, 
                       b.category_id as categoryId
                   from books as b
                   left join categories as c on b.category_id = c.id
                   where b.id = @id;
                   """;
        return connection.QueryFirstOrDefaultAsync<Book>(sql, new {id});

    }

    public Task<int> Add(Book book)
    {
        var sql = """
                  insert into books ( 
                  id,
                  name, 
                  author,
                  ref_img, 
                  create_date, 
                  description,
                  date_added,
                  category_id) 
                  values (
                  @id,
                  @name, 
                  @author,
                  @refImg, 
                  @createDate, 
                  @description, 
                  @dateAdded,
                  @categoryId)
                  """;
        book.DateAdded = DateTime.Now;

        return connection.QuerySingleAsync<int>(sql, new
        {
            book.Id,
            book.Author,
            book.RefImg,
            book.CreateDate,
            book.Description,
            book.CategoryId
        });

    }

    public Task<StatusBook> Update(StatusBook book)
    {
        var sql = """
                  update statuses_books set 
                  status = @status
                  where id = @bookId;
                  """;
        return connection.QuerySingleAsync<StatusBook>(sql, new
        {
            book.BookId,
            book.Status
        });
    }

    public Task Delete(long id)
    {
        const string sql = "delete from books where id = @id";
        return connection.ExecuteAsync(sql, new { id });
    }
}