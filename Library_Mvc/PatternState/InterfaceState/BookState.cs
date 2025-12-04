namespace Library_Mvc.PatternState.InterfaceState;

public abstract class BookState
{
    public abstract string Name { get; }
    public abstract bool CanBorrow();
}