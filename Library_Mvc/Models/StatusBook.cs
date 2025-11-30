using Library_Mvc.Enum;

namespace Library_Mvc.Models;

public class StatusBook
{
    public long Id { get; set; }
    public long BookId { get; set; }
    public Statuses Status { get; set; } 
}