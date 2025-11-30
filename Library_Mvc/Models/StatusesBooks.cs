using Library_Mvc.Enum;

namespace Library_Mvc.Models;

public class StatusesBooks
{
    public long Id { get; set; }
    public long IdBook { get; set; }
    public Statuses Status { get; set; } 
}