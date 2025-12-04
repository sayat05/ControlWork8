namespace Library_Mvc.Models;

public class BorrowedBook
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long BookId { get; set; }
    public DateTime DateTaken { get; set; }
    public DateTime DateReturned { get; set; }
}