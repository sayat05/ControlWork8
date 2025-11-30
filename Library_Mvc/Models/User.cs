namespace Library_Mvc.Models;

public class User
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required string Lastname { get; set; }
    public required string Email { get; set; }
    public string? PhoneNumber { get; set; }
}