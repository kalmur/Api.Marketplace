using Api.Marketplace.Application.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Marketplace.Persistence.EntityConfiguration;

public class CityEntityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder
            .ToTable("City")
            .HasKey(x => x.CityId);

        builder
            .HasMany(x => x.Listings)
            .WithOne(x => x.City)
            .HasForeignKey(x => x.CityId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Property(x => x.Name)
            .IsRequired();

        builder
            .Property(x => x.Country)
            .IsRequired();

        builder
            .Property(x => x.CreatedOn)
            .IsRequired();

        builder
            .Property(x => x.UpdatedOn);
    }
}
