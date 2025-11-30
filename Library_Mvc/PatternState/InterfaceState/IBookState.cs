using Library_Mvc.Enum;
using Library_Mvc.PatternState.ContextModel;

namespace Library_Mvc.PatternState.InterfaceState;

public interface IBookState
{
    void Issued(BookContext context);
    void InStock(BookContext context);
    Statuses ToEnum();
}