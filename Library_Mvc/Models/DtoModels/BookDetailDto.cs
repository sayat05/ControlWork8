using Library_Mvc.Enum;

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
    public long CategoryId { get; set; }
    public required string CategoryName { get; set; }
    public required string StatusStr { get; set; }
    public Statuses StatusInt { get; set; }
}