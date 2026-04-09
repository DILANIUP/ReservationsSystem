using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationsSystem.Domain.Entities;

namespace ReservationsSystem.Infrastructure.Persistence.Configurations
{

    public sealed class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasKey(hotel => hotel.Id);

            builder.HasOne(hotel => hotel.Resource)
                .WithOne(resource => resource.Hotel)
                .HasForeignKey<Hotel>(hotel => hotel.ResourceId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }

}