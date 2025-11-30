using Library_Mvc.Models;

namespace Library_Mvc.Interfaces;

public interface ICategoryRepositories
{
    Task<IEnumerable<Category>> GetAll();
    Task<Category?> GetById(long id);
    Task<Category?> GetByName(string name);
    Task Add(Category category);
    Task Update(Category category);
    Task Delete(long id);
}