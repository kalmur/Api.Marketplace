namespace Api.Marketplace.Application.Interfaces.Services;

public interface IPasswordValidator
{
    bool ValidatePassword(string password);
}
