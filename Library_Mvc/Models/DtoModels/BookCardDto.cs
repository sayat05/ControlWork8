namespace Library_Mvc.Models.DtoModels;

public class BookCardDto
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required string Author { get; set; }
    public required string RefImg { get; set; }
    public required string Status { get; set; }
}