using Library_Mvc.PatternState.InterfaceState;

namespace Library_Mvc.PatternState.ConcreteStates;

public class InStockState : BookState
{
    public override string Name => "В наличий";
    public override bool CanBorrow() => true;
}