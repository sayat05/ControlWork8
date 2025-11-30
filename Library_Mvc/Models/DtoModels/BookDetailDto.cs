namespace Library_Mvc.Models.DtoModels;

public class BookDetailDto
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required string Author { get; set; }
    public required string RefImg { get; set; }
    public DateTime CreateDate { get; set; }
    public string? Description { get; set; }
    public DateTime DateAdded { get; set; }
    public required string CategoryName { get; set; }
    public required string Status { get; set; }
}