namespace Api.Marketplace.Application.Models;

public class Auth0UserModel
{
    public Auth0UserModel(string? userId, string? name)
    {
        UserId = userId;
        Name = name;
    }

    public string? UserId { get; set; }
    public string? Name { get; set; }
}
