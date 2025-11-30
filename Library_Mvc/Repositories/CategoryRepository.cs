using System.Data;
using Dapper;
using Library_Mvc.Interfaces;
using Library_Mvc.Models;

namespace Library_Mvc.Repositories;

public class CategoryRepository(IDbConnection connection) : ICategoryRepositories
{
    public Task<IEnumerable<Category>> GetAll()
    {
        var sql = "select * from categories ";
        return connection.QueryAsync<Category>(sql);
    }

    public Task<Category?> GetById(long id)
    {
        var sql = "select * from categories where id = @id";
        return connection.QueryFirstOrDefaultAsync<Category>(sql, new { id });
    }

    public Task<Category?> GetByName(string name)
    {
        var sql = "select * from categories where name = @name";
        return connection.QueryFirstOrDefaultAsync<Category>(sql, new { name });
    }

    public Task Add(Category category)
    {
        var sql = """
                  insert into categories(name)
                  values (@id, @name)
                  """;
        return connection.ExecuteAsync(sql, new
        {
            category.Id,
            category.Name
        });
    }

    public Task Update(Category category)
    {
        var sql = """
                  update categories set
                  name = @name
                  where id = @id
                  """;
        return connection.QuerySingleAsync<Category>(sql, new
        {
            category.Id,
            category.Name
        });

    }

    public Task Delete(long id)
    {
        const string sql = "delete from categories where id = @id";
        return connection.ExecuteAsync(sql, new { id });
    }
}