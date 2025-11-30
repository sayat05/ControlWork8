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
        throw new NotImplementedException();
    }

    public Task Add(Book book)
    {
        throw new NotImplementedException();
    }

    public Task<Book> Update(StatusesBooks book)
    {
        throw new NotImplementedException();
    }

    public Task Delete(long id)
    {
        throw new NotImplementedException();
    }
}