namespace Library_Mvc.Models;

public class LibraryUsers
{
    public long Id { get; set; }
    public required List<User> Users { get; set; }
}

