using Library_Mvc.Enum;

namespace Library_Mvc.Models.DtoModels;

public class BookDetailDto
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required string Author { get; set; }
    public required string RefImg { get; set; }
    public int YearOfRelease { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public required string CategoryName { get; set; }
    public required string Status { get; set; }
}