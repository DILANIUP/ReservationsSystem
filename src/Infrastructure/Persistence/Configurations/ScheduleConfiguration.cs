using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationsSystem.Domain.Entities;

namespace ReservationsSystem.Infrastructure.Persistence.Configurations
{

    public sealed class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(schedule => schedule.Id);

            builder.Property(schedule => schedule.OpenTime)
            .HasColumnName("open_time")
            .HasColumnType("time")
            .IsRequired();

            builder.Property(schedule => schedule.CloseTime)
            .HasColumnName("close_time")
            .HasColumnType("time")
            .IsRequired();
            
            builder.HasOne(schedule => schedule.Resource)
            .WithMany() // sin navegación del otro lado
            .HasForeignKey(schedule => schedule.ResourceId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(schedule => schedule.DaysOfWeek)
            .WithMany()
            .UsingEntity("ScheduleCatalogues");
                                

        }
    }   

}