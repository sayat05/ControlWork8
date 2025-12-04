namespace Library_Mvc.Models.DtoModels;

public class BorrowedBookDto
{
    public long BorrowId { get; set; } 
    public required string BookName { get; set; }
    public required string Author { get; set; }
    public required string UserFullName { get; set; }
    public DateTime DateTaken { get; set; }
}
