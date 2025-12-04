using Library_Mvc.PatternState.ConcreteStates;
using Library_Mvc.PatternState.InterfaceState;

namespace Library_Mvc.PatternState.ContextModel;
public class BookStatusContext(bool isBorrowed)
{
    private readonly BookState _state = 
        isBorrowed ? new IssuedState() : new InStockState();

    public string GetStatus() => _state.Name;

    public bool CanBorrow() => _state.CanBorrow();
}