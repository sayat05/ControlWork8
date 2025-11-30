namespace Library_Mvc.Models.DtoModels;

public class BookAddDto
{
    public required string Name { get; set; }
    public required string Author { get; set; }
    public required string RefImg { get; set; }
    public DateTime CreateDate { get; set; }
    public string? Description { get; set; }
    public required string CategoryName { get; set; }
}