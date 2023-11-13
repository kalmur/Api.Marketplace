using Api.Marketplace.Application.Interfaces.Services;
using Api.Marketplace.Application.Options;
using Api.Marketplace.Application.Services;
using Auth0Net.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Marketplace.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var currentAssembly = typeof(DependencyInjection).Assembly;

        services.AddMediatR(config => config.RegisterServicesFromAssembly(currentAssembly));

        services
            .AddSingleton<IPasswordService, PasswordService>()
            .AddSingleton<IPasswordGenerator, PasswordGenerator>()
            .AddSingleton<IPasswordValidator, PasswordValidator>();

        RegisterAuth0Services(services, configuration);

        return services;
    }

    private static void RegisterAuth0Services(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<Auth0Options>(configuration.GetSection(Auth0Options.SectionName));

        var options = configuration.GetSection(Auth0Options.SectionName).Get<Auth0Options>();

        services.AddScoped<IAuth0UsersClient, Auth0UsersClient>();
        services.AddScoped<IIdentityProviderService, Auth0Service>();
        services.AddScoped<IAuth0QueryBuilder, Auth0QueryBuilder>();

        services.AddAuth0AuthenticationClient(config =>
        {
            config.Domain = options!.Domain!;
            config.ClientId = options.ClientId;
            config.ClientSecret = options.ClientSecret;
        });
        services.AddAuth0ManagementClient().AddManagementAccessToken();
    }
}
