using Library_Mvc.Models;
using Library_Mvc.Models.DtoModels;

namespace Library_Mvc.Interfaces;

public interface IUserRepository
{
    Task<long> CreateAsync(UserCreateDto userCreateDto);
    Task<User?> GetByEmailAsync(string email);
}