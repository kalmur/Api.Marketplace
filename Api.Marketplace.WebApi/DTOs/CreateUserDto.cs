namespace Api.Marketplace.WebApi.DTOs;

public class CreateUserDto
{
    public CreateUserDto(string username)
    {
        Username = username;
    }

    public string Username { get; set; }
}
