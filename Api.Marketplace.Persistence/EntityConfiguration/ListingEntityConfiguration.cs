using Api.Marketplace.Domain.Entities;
using Api.Marketplace.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Marketplace.Persistence.EntityConfiguration;

public class ListingEntityConfiguration : IEntityTypeConfiguration<Listing>
{
    public void Configure(EntityTypeBuilder<Listing> builder)
    {
        builder
            .ToTable(TableNames.Listings)
            .HasKey(x => x.ListingId);

        builder.Property(x => x.ListingId).ValueGeneratedOnAdd();

        builder.Property(x => x.SellLease).IsRequired();

        builder.Property(x => x.Name).IsRequired().HasMaxLength(200);

        builder.Property(x => x.Category).IsRequired();

        builder.Property(x => x.Description);

        builder.Property(x => x.Price);

        builder.Property(x => x.Address);

        builder.Property(x => x.PostCode);

        builder.Property(x => x.AvailableFrom);

        builder
            .Property(x => x.CreatedOn);

        builder
            .Property(x => x.UpdatedOn);

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.Listings)
            .HasForeignKey(x => x.CityId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.City)
            .WithMany(x => x.Listings)
            .HasForeignKey(x => x.CityId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(x => x.Reviews)
            .WithOne(x => x.Listing)
            .HasForeignKey(x => x.ListingId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
