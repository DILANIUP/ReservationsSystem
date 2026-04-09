using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationsSystem.Domain.Entities;

namespace ReservationsSystem.Infrastructure.Persistence.Configurations
{

    public sealed class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(reservation => reservation.Id);

            builder.OwnsOne(reservation => reservation.ReservationSlot, reservationSlot =>
            {
                reservationSlot.Property(rs => rs.Date)
                .HasColumnName("date")
                .HasColumnType("date")
                .IsRequired();

                reservationSlot.Property(rs => rs.StartTime)
                .HasColumnName("start_time")
                .HasColumnType("time")
                .IsRequired();

                reservationSlot.Property(rs => rs.EndTime)
                .HasColumnName("end_time")
                .HasColumnType("time")
                .IsRequired();

            });

            builder.OwnsOne(reservation => reservation.TotalAmount, totalAmount =>
            {
                totalAmount.Property(ta => ta.Amount)
                .HasColumnName("amount")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

                totalAmount.Property(ta => ta.Currency)
                .HasColumnName("currency")
                .HasColumnType("char(3)")
                .IsRequired();

            });

            builder.OwnsOne(reservation => reservation.AdvancedPayment, advancedPayment =>
            {
                advancedPayment.Property(ap => ap.Amount)
                .HasColumnName("amount")
                .HasColumnType("decimal(18,2)")
                .IsRequired(false);

                advancedPayment.Property(ap => ap.Currency)
                .HasColumnName("currency")
                .HasColumnType("char(3)")
                .IsRequired(false);

            });

            builder.Property(reservation => reservation.GuestCount)
            .HasColumnName("guest_count")
            .HasColumnType("int")
            .IsRequired();


            builder.Property(reservation => reservation.Status)
            .HasColumnName("status")
            .HasConversion<string>()
            .HasColumnType("nvarchar(20)")
            .IsRequired();

            builder.Property(reservation => reservation.SpecialRequests)
            .HasColumnName("special_requests")
            .HasColumnType("nvarchar(250)");

            builder.HasOne(reservation => reservation.User)
            .WithMany(user => user.Reservations)
            .HasForeignKey(reservation => reservation.UserId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(reservation => reservation.Resource)
            .WithMany(resource => resource.Reservations)
            .HasForeignKey(reservation => reservation.ResourceId)
            .OnDelete(DeleteBehavior.Restrict);

        }

    }
}