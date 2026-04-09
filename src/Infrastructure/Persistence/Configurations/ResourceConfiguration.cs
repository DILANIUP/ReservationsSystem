using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationsSystem.Domain.Entities;

namespace ReservationsSystem.Infrastructure.Persistence.Configurations
{

    public sealed class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.HasKey(resource => resource.Id);

            builder.Property(resource => resource.Name)
            .HasColumnName("name")
            .HasColumnType("nvarchar(50)")
            .IsRequired();

            builder.Property(resource => resource.Phone)
            .HasColumnName("phone")
            .HasColumnType("nvarchar(15)")
            .IsRequired();

            builder.Property(resource => resource.Website)
            .HasColumnName("website")
            .HasColumnType("nvarchar(100)");

            builder.Property(resource => resource.Description)
            .HasColumnName("description")
            .HasColumnType("nvarchar(250)");

            builder.Property(resource => resource.Type)
            .HasColumnName("type")
            .HasConversion<string>()
            .HasColumnType("nvarchar(20)")
            .IsRequired();

            builder.Property(resource => resource.IsActive)
            .HasColumnName("is_active")
            .HasColumnType("bit")
            .IsRequired();

            
            builder.OwnsOne(
                resource => resource.Email,
                email =>
                {
                    email.Property(email => email.Value)
                    .HasColumnName("value")
                    .HasColumnType("nvarchar(150)")
                    .IsRequired();                    
                }
            );
            builder.OwnsOne(
                resource => resource.Address,
                address =>
                {
                    address.Property(address => address.City)
                    .HasColumnName("city")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();              

                    address.Property(address => address.Street)
                    .HasColumnName("street")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();                    
                }
            );
            


        }
    }   

}


