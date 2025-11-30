using Library_Mvc.Models;

namespace Library_Mvc.Interfaces;

public interface ILibraryUserRepository
{
    Task<IEnumerable<LibraryUser>> GetAll();
    Task<LibraryUser?> GetById(long id);
    Task Add(LibraryUser libraryUser);
    Task Update(LibraryUser libraryUser);
    Task Delete(long id);
}