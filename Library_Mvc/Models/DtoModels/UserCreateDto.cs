namespace Library_Mvc.Models.DtoModels;

public class UserCreateDto
{
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
}