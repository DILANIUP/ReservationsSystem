using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationsSystem.Domain.Entities;

namespace ReservationsSystem.Infrastructure.Persistence.Configurations
{

    public sealed class FlatConfiguration : IEntityTypeConfiguration<Flat>
    {
        public void Configure(EntityTypeBuilder<Flat> builder)
        {
            builder.HasKey(flat => flat.Id);

            builder.Property(flat => flat.FlatNumber)
            .HasColumnName("flat_number")
            .HasColumnType("int")
            .IsRequired();

            builder.Property(flat => flat.IsActive)
            .HasColumnName("is_active")
            .HasColumnType("bit")
            .IsRequired();

            builder.HasOne(flat => flat.Restaurant)
            .WithMany(restaurant=> restaurant.Flats)
            .HasForeignKey(flat => flat.RestaurantId)
            .OnDelete(DeleteBehavior.Cascade);

        }

    }
}