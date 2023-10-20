using Api.Marketplace.Application.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Marketplace.Persistence.EntityConfiguration;

public class ListingEntityConfiguration : IEntityTypeConfiguration<Listing>
{
    public void Configure(EntityTypeBuilder<Listing> builder)
    {
        builder
            .ToTable("Listing")
            .HasKey(x => x.ListingId);

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.Listings)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.City)
            .WithMany(x => x.Listings)
            .HasForeignKey(x => x.CityId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Property(x => x.SellLease)
            .IsRequired();

        builder
            .Property(x => x.Name)
            .IsRequired();

        builder
            .Property(x => x.Category)
            .IsRequired();

        builder
            .Property(x => x.Description);

        builder
            .Property(x => x.Price)
            .IsRequired()
            .HasPrecision(18, 2);

        builder
            .Property(x => x.Address)
            .IsRequired();

        builder
            .Property(x => x.PostCode)
            .IsRequired();

        builder
            .Property(x => x.AvailableFrom)
            .IsRequired();

        builder
            .Property(x => x.CreatedOn)
            .IsRequired();

        builder
            .Property(x => x.UpdatedOn);
    }
}
