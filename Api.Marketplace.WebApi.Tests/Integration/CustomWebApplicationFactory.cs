using Api.Marketplace.Application.Interfaces;
using Api.Marketplace.Domain.Entities;
using Api.Marketplace.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Marketplace.WebApi.Tests.Integration;

public abstract class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    private readonly string _connectionString = Guid.NewGuid().ToString();
    private readonly InMemoryDatabaseRoot _databaseRoot = new();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var dbContextDescriptor = services.SingleOrDefault(x =>
                x.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));

            if (dbContextDescriptor is not null)
                services.Remove(dbContextDescriptor);

            var appDbContextDescriptor = services.SingleOrDefault(x =>
                x.ServiceType == typeof(IApplicationDbContext));

            if (appDbContextDescriptor is not null)
                services.Remove(appDbContextDescriptor);

            services.AddEntityFrameworkInMemoryDatabase()
                .AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseInMemoryDatabase(_connectionString, _databaseRoot);
                    options.UseInternalServiceProvider(services.BuildServiceProvider());
                });

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

            using var scoped = services.BuildServiceProvider().CreateScope();

            var dbContext = scoped
                .ServiceProvider
                .GetRequiredService<ApplicationDbContext>();

            dbContext.Database.CanConnect();
            dbContext.Database.EnsureCreated();
            SeedData(dbContext);
        });
    }

    private static void SeedData(ApplicationDbContext context)
    {
        //var cities = new List<City>
        //{
        //    new()
        //    {
        //        CityId = 1,
        //        Name = "Szeged",
        //        Country = "Hungary",
        //        CreatedOn = DateTime.Now,
        //        UpdatedOn = DateTime.Now.AddHours(1)
        //    },
        //    new()
        //    {
        //        CityId = 2,
        //        Name = "Budapest",
        //        Country = "Hungary",
        //        CreatedOn = DateTime.Now,
        //        UpdatedOn = DateTime.Now.AddHours(1)
        //    }
        //};

        //context.Cities.AddRange(cities);
        context.SaveChangesAsync();
    }
}
