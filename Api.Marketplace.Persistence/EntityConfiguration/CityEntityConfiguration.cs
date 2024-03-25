using Api.Marketplace.Application.Entities;
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

        builder.Property(x => x.CityId).ValueGeneratedOnAdd();

        builder.Property(x => x.Name).IsRequired().HasMaxLength(200);

        builder.Property(x => x.Country).IsRequired().HasMaxLength(200);

        builder
            .Property(x => x.CreatedOn)
            .IsRequired();

        builder
            .Property(x => x.UpdatedOn);

        builder
            .HasMany(x => x.Listings)
            .WithOne(li => li.City)
            .HasForeignKey(li => li.CityId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
