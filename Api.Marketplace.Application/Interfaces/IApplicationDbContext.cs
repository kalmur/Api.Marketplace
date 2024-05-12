using Api.Marketplace.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Marketplace.Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Listing> Listings { get; }
    DbSet<User> Users { get; }
    DbSet<Review> Reviews { get; }  
    DbSet<Photo> Photos { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
