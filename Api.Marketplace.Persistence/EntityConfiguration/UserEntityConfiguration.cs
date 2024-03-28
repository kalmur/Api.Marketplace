using Api.Marketplace.Domain.Entities;
using Api.Marketplace.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Marketplace.Persistence.EntityConfiguration;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .ToTable(TableNames.User)
            .HasKey(x => x.UserId);

        builder.Property(x => x.UserId).ValueGeneratedOnAdd();

        builder.Property(x => x.ExternalProviderId).HasMaxLength(200);

        builder
            .HasMany(x => x.Listings)
            .WithOne(li => li.User)
            .HasForeignKey(li => li.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
