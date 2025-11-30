using System.Data;
using Dapper;
using Library_Mvc.Interfaces;
using Library_Mvc.Models;

namespace Library_Mvc.Repositories;

public class LibraryUserRepository(IDbConnection connection) : ILibraryUserRepository
{
    public Task<IEnumerable<LibraryUser>> GetAll()
    {
        var sql = """
                  select 
                      id,
                      user_id as UserId,
                      date_added as DateAdded
                  from library_users
                  """;
        return connection.QueryAsync<LibraryUser>(sql);
    }

    public Task<LibraryUser?> GetById(long id)
    {
        var sql = """
                   
                  select 
                      id,
                      user_id as UserId, 
                      date_added as DateAdded
                  from library_users 
                  where id = @id;

                  """;
        return connection.QueryFirstOrDefaultAsync<LibraryUser>(sql, new { id });
    }

    public Task Add(LibraryUser libraryUser)
    {
        var sql = """
                  insert into library_users(user_id, date_added)
                  values (@userId, @dateAdded)
                  """;
        return connection.ExecuteAsync(sql, new
        {
            libraryUser.UserId,
            libraryUser.DateAdded
        });
    }

    public Task Update(LibraryUser libraryUser)
    {
        var sql = """
                  update library_users set
                  user_id = @userId,
                  date_added = @dateAdded
                  where id = @id
                  """;
        return connection.QuerySingleAsync<LibraryUser>(sql, libraryUser);
    }

    public Task Delete(long id)
    {
        const string sql = "delete from library_users where id = @id";
        return connection.ExecuteAsync(sql, new { id });
    }
}