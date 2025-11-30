namespace Library_Mvc.Models;

public class BookIssued
{
    public long UserId { get; set; }
    public long BookId { get; set; }
    public DateTime IssuedDate { get; set; }
    public DateTime ReturnDate { get; set; }
}