using Api.Marketplace.Application.Interfaces;
using Api.Marketplace.Domain.Entities;
using Api.Marketplace.Persistence;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

#nullable enable
namespace Api.Marketplace.Application.Tests.Workflows;

public class WorkflowBaseTests
{
    private SqliteConnection _connection;
    private ApplicationDbContext _context;

    protected IApplicationDbContext Context;
    //protected City DemoCity1;
    //protected City DemoCity2;
    protected Listing DemoListing1;
    protected Listing DemoListing2;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _connection = new SqliteConnection("DataSource=:memory:");
        _connection.Open();
        var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlite(_connection)
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging().Options;

        _context = new ApplicationDbContext(dbOptions);
        _context.Database.EnsureCreated();

        AddListings();

        _context.SaveChanges();

        Context = _context;
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _connection.Close();
        _context.Dispose();
    }

    [SetUp]
    [TearDown]
    public void BeforeAndAfterEveryTest()
    {
        try
        {
            //RemoveEntries<City>();
            RemoveEntries<Listing>();
            RemoveEntries<Domain.Entities.User>();
            _context.SaveChangesAsync().Wait();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    protected void AddEntry<T>(T entry) where T : class
    {
        _context.Set<T>().Add(entry);
        _context.SaveChangesAsync().Wait();
    }

    protected void RemoveEntries<T>() where T : class
    {
        var entries = _context.Set<T>().ToList();
        if (!entries.Any()) return;
        _context.RemoveRange(entries);
    }

    private void AddListings()
    {
        DemoListing1 = new Listing()
        {
            ListingId = 1,
            UserId = 1,
            SellLease = 1,
            Name = "MSI GE75",
            Category = "Laptop",
            Description = "Gaming laptop",
            Price = 2000,
            Address = "15 Jump street",
            PostCode = "EH48 2FF",
            AvailableFrom = DateTime.Now
        };

        AddEntry(DemoListing1);
    }
}
#nullable disable
