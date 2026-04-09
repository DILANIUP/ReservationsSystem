using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationsSystem.Domain.Entities;

namespace ReservationsSystem.Infrastructure.Persistence.Configurations
{

    public sealed class TableConfiguration : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder.HasKey(table => table.Id);

            builder.Property(table => table.TableNumber)
            .HasColumnName("table_number")
            .HasColumnType("int")
            .IsRequired();

            builder.Property(table => table.Capacity)
            .HasColumnName("capacity")
            .HasColumnType("int")
            .IsRequired();

            builder.Property(table => table.Location)
            .HasColumnName("location")
            .HasColumnType("nvarchar(50)")
            .IsRequired();

            builder.Property(table => table.IsActive)
            .HasColumnName("is_active")
            .HasColumnType("bit")
            .IsRequired();
            
            builder.HasOne(table => table.Flat)
            .WithMany(flat => flat.Tables)
            .HasForeignKey(table => table.FlatId)
            .OnDelete(DeleteBehavior.Cascade);
            
            

        }
    }   

}