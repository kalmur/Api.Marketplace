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
    protected City DemoCity1;
    protected City DemoCity2;

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

        AddUserNote();

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
            RemoveEntries<City>();
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

    private void AddUserNote()
    {
        DemoCity1 = new City()
        {
            CityId = 1,
            Name = "Szeged",
            Country = "Hungary",
            CreatedOn = DateTime.Now,
            UpdatedOn = DateTime.Now.AddHours(1)
        };

        DemoCity2 = new City()
        {
            CityId = 2,
            Name = "Budapest",
            Country = "Hungary",
            CreatedOn = DateTime.Now,
            UpdatedOn = DateTime.Now.AddHours(1)
        };

        AddEntry(DemoCity1);
        AddEntry(DemoCity2);
    }
}
#nullable disable
