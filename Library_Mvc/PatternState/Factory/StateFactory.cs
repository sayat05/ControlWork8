using Library_Mvc.Enum;
using Library_Mvc.PatternState.ConcreteStates;
using Library_Mvc.PatternState.InterfaceState;

namespace Library_Mvc.PatternState.Factory;

public static class StateFactory
{
    public static BookState FromStatus(Statuses status) =>
        status switch
        {
            Statuses.Issued => new IssuedState(),
            Statuses.InStock => new InStockState(),
            _ => throw new ArgumentOutOfRangeException(nameof(status), status, null)
        };
}