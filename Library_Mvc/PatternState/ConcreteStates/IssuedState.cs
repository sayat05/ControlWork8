using Library_Mvc.PatternState.InterfaceState;

namespace Library_Mvc.PatternState.ConcreteStates;

public class IssuedState : BookState
{
    public override string Name => "Выдана";

    public override bool CanBorrow() => false;
}