namespace Library_Mvc.Models.DtoModels;

public class BorrowRequestDto
{
    public long BookId { get; set; }
    public required string UserEmail { get; set; }
}