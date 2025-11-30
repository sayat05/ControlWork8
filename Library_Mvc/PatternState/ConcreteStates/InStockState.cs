using Library_Mvc.Enum;
using Library_Mvc.PatternState.ContextModel;
using Library_Mvc.PatternState.InterfaceState;

namespace Library_Mvc.PatternState.ConcreteStates;

public class InStockState : IBookState
{
    public void Issued(BookContext context)
    {
        Console.WriteLine("Выдача книги");
        context.CurrentBook.Status = Statuses.Issued;
        context.SetState(new IssuedState());
    }

    public void InStock(BookContext context)
    {
        Console.WriteLine("Книга в состояний наличий");
    }

    public Statuses ToEnum() => Statuses.InStock;
}