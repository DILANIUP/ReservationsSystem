using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationsSystem.Domain.Entities;

namespace ReservationsSystem.Infrastructure.Persistence.Configurations
{

    public sealed class ExeptionDateConfiguration : IEntityTypeConfiguration<ExceptionDate>
    {
        public void Configure(EntityTypeBuilder<ExceptionDate> builder)
        {
            builder.HasKey(exceptionDate => exceptionDate.Id);

            builder.Property(exceptionDate => exceptionDate.Date)
            .HasColumnName("date")
            .HasColumnType("date")
            .IsRequired();

            builder.Property(exceptionDate => exceptionDate.Reason)      
            .HasColumnName("Reason")
            .HasColumnType("nvarchar(100)");

            builder.HasOne(exceptionDate => exceptionDate.Resource)
            .WithMany(resource => resource.ExceptionDates)
            .HasForeignKey(exceptionDate => exceptionDate.ResourceId)
            .OnDelete(DeleteBehavior.Cascade);


        }
    }   

}