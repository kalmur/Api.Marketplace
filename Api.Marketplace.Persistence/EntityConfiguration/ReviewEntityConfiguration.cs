using Api.Marketplace.Domain.Entities;
using Api.Marketplace.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Marketplace.Persistence.EntityConfiguration
{
    public class ReviewEntityConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder
                .ToTable(TableNames.Reviews)
                .HasKey(x => x.ReviewId);

            builder.Property(x => x.ReviewId).ValueGeneratedOnAdd();

            builder.Property(x => x.UserId).IsRequired();

            builder.Property(x => x.ListingId).IsRequired();

            builder.Property(x => x.Rating);

            builder.Property(x => x.Comment);

            builder
                .Property(x => x.CreatedOn);

            builder
                .Property(x => x.UpdatedOn);

            builder
                .HasOne(x => x.User)
                .WithMany(c => c.Reviews)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Listing)
                .WithMany(c => c.Reviews)
                .HasForeignKey(c => c.ListingId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
