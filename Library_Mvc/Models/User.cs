namespace Library_Mvc.Models;

public class User
{
    public long Id { get; set; }
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public required string Email { get; set; }
    public required  string Phone { get; set; }
}