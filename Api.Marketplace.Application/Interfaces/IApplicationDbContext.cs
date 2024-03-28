using Api.Marketplace.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Marketplace.Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<City> Cities { get; }
    DbSet<Listing> Listings { get; }
    DbSet<User> Users { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
