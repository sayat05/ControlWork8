namespace Library_Mvc.Models;

public class Book
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required string Author { get; set; }
    public required string RefImg { get; set; }
    public DateTime CreateDate { get; set; }
    public string? Description { get; set; }
    public DateTime DateAdded { get; set; }
    public long CategoryId { get; set; }
}