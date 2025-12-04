using System.Data;
using Dapper;
using Library_Mvc.Interfaces;
using Library_Mvc.Models;
using Library_Mvc.Models.DtoModels;

namespace Library_Mvc.Repositories;

public class UserRepository(IDbConnection connection) : IUserRepository
{
    public async Task<long> CreateAsync(UserCreateDto userCreateDto)
    {
        var sql = """
                  insert into users (first_name, last_name, email, phone) 
                  values (@firstName, @lastName, @email, @phone)
                  returning id;
                  """;
        return await connection.ExecuteScalarAsync<long>(sql, userCreateDto);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        var sql = """"
                  select 
                      u.id,
                      u.first_name as firstName,
                      u.last_name as lastName,
                      u.email,
                      u.phone
                  from users u
                  """";
        return await connection.QuerySingleOrDefaultAsync<User>(sql, new { email });
    }
}