using Library_Mvc.Models;

namespace Library_Mvc.Interfaces;

public interface IStatusBookRepository
{
    Task<IEnumerable<StatusBook>> GetAll();
    Task<StatusBook?> GetById(long id);
    Task Add(StatusBook statusBook);
    Task Update(StatusBook statusBook);
    Task Delete(long id);
}