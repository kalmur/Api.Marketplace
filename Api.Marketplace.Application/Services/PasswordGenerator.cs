using Api.Marketplace.Application.Interfaces.Services;
using IdentityModel;

namespace Api.Marketplace.Application.Services;

public class PasswordGenerator : IPasswordGenerator
{
    public string GetNewPassword()
    {
        return Base64Url.Encode(CryptoRandom.CreateRandomKey(20));
    }
}
