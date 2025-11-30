using Library_Mvc.Models;
using Library_Mvc.PatternState.Factory;
using Library_Mvc.PatternState.InterfaceState;

namespace Library_Mvc.PatternState.ContextModel;

public class BookContext(StatusBook book)
{
    private IBookState _state = StateFactory.FromStatus(book.Status);
    public StatusBook CurrentBook { get; } = book;

    public void SetState(IBookState state)
    {
        _state = state;
        CurrentBook.Status = _state.ToEnum();
    }

    public void Issued() => _state.Issued(this);
    public void InStock() => _state.InStock(this);
}