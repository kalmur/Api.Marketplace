using Api.Marketplace.Application.Interfaces.Services;
using Api.Marketplace.Application.Options;
using Api.Marketplace.Application.Services;
using Api.Marketplace.Application.Services.Cache;
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

        RegisterAuth0(services, configuration);
        Auth0Authentication(services, configuration);

        return services;
    }

    private static IServiceCollection RegisterAuth0(
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
                client.BaseAddress = new Uri(options!.Domain!);
            });

        return services;
    }

    private static void AddAuth0Authentication(
        this IServiceCollection services,
        Action<Auth0Options> config)
    {
        services.AddOptions<Auth0Options>()
            .Configure(config)
            .Validate(x => !string.IsNullOrWhiteSpace(x.ClientId) && !string.IsNullOrWhiteSpace(x.Domain) && !string.IsNullOrWhiteSpace(x.ClientSecret),
                "Auth0 Configuration cannot have empty values");

        services.AddFusionCache(Constants.FusionCacheInstance);

        services.AddScoped<IAuth0TokenCache, Auth0TokenCache>();
    }

    private static void Auth0Authentication(
        IServiceCollection services,
        IConfiguration configuration)
    {
        var options = configuration.GetSection(Auth0Options.SectionName).Get<Auth0Options>();
    }
}
