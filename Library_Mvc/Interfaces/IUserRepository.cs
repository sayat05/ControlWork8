using Library_Mvc.Models;
using Library_Mvc.Models.DtoModels;

namespace Library_Mvc.Interfaces;

public interface IUserRepository
{
    Task<long> Create(UserCreateDto userCreateDto);
    Task<User?> GetByEmail(string email);
}