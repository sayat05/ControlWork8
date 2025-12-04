using Library_Mvc.PatternState.ConcreteStates;
using Library_Mvc.PatternState.InterfaceState;

namespace Library_Mvc.PatternState.ContextModel;
public class BookStatusContext(string status)
{
    private BookState State { get; set; } = status switch
    {
        "Выдана" => new IssuedState(),
        _ => new InStockState()
    };

    public string GetStatus() => State.Name;

    public bool CanBorrow() => State.CanBorrow();

    public void SetIssued()
    {
        State = new IssuedState();
    }

    public void SetInStock()
    {
        State = new InStockState();
    }
    
}