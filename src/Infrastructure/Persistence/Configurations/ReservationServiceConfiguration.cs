using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationsSystem.Domain.Entities;

namespace ReservationsSystem.Infrastructure.Persistence.Configurations
{

    public sealed class ReservationServiceConfiguration : IEntityTypeConfiguration<ReservationService>
    {
        public void Configure(EntityTypeBuilder<ReservationService> builder)
        {
            builder.HasKey(reservationService => reservationService.Id);

            builder.Property(reservationService => reservationService.Status)
            .HasColumnName("status")
            .HasConversion<string>()
            .HasColumnType("nvarchar(20)")
            .IsRequired();

            builder.HasOne(reservationService => reservationService.Reservation)
            .WithMany(reservation => reservation.ReservationServices)
            .HasForeignKey(reservationService => reservationService.ReservationId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(reservationService => reservationService.AdditionalService)
            .WithMany(additionalService => additionalService.ReservationServices)
            .HasForeignKey(reservationService => reservationService.AdditionalServiceId)
            .OnDelete(DeleteBehavior.Cascade);
        }

    }
}