using Api.Marketplace.Application.Interfaces.Services;
using Api.Marketplace.Application.Options;
using Api.Marketplace.Application.Services;
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

        services.Configure<Auth0Options>(configuration.GetSection(Auth0Options.SectionName));

        return services;
    }

    private static IServiceCollection AddAuth0(
        IServiceCollection services,
        IConfiguration configuration)
    {
        var options = configuration.GetSection(Auth0Options.SectionName).Get<Auth0Options>();

        services
            .AddScoped<IIdentityProviderService, Auth0Service>()
            .AddScoped<IAuth0QueryBuilder, Auth0QueryBuilder>()
            .AddScoped<Auth0TokenHandler>();

        services
            .AddHttpClient(ClientNames.Auth0, client =>
            {
                client.BaseAddress = new Uri(options!.)
            })

        return services;
    }

    private static void Auth0Authentication(
        IServiceCollection services,
        IConfiguration configuration)
    {
        var options = configuration.GetSection(Auth0Options.SectionName).Get<Auth0Options>();
    }
}
