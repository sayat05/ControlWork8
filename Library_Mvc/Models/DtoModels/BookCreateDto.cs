namespace Library_Mvc.Models.DtoModels;

public class BookCreateDto
{
    public required string Name { get; set; }
    public required string Author { get; set; }
    public required string RefImg { get; set; }
    public int YearOfRelease { get; set; }
    public string? Description { get; set; }
    public required int CategoryId { get; set; }
}