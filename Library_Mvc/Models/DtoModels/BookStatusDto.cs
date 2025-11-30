using Library_Mvc.Enum;

namespace Library_Mvc.Models.DtoModels;

public class BookStatusDto
{
    public required string Name { get; set; }
    public required string Author { get; set; }
    public Statuses Status { get; set; }
}