using Library_Mvc.Enum;
using Library_Mvc.PatternState.ContextModel;
using Library_Mvc.PatternState.InterfaceState;

namespace Library_Mvc.PatternState.ConcreteStates;

public class IssuedState : IBookState
{
    public void Issued(BookContext context)
    {
        Console.WriteLine("Книга уже выдана пользователю");
    }

    public void InStock(BookContext context)
    {
        Console.WriteLine("Нельзя получить выданную книгу");
    }

    public Statuses ToEnum() => Statuses.Issued;
}