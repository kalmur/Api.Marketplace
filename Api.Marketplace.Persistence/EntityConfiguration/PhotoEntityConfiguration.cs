using Api.Marketplace.Domain.Entities;
using Api.Marketplace.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Marketplace.Persistence.EntityConfiguration
{
    public class PhotoEntityConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder
                .ToTable(TableNames.Photos)
                .HasKey(x => x.PhotoId);

            builder.Property(x => x.PhotoId).ValueGeneratedOnAdd();

            builder.Property(x => x.ListingId).IsRequired();

            builder.Property(x => x.Url).IsRequired();

            builder.Property(x => x.IsPrimary);

            builder
                .HasOne(x => x.Listing)
                .WithMany(c => c.Photos)
                .HasForeignKey(c => c.ListingId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
