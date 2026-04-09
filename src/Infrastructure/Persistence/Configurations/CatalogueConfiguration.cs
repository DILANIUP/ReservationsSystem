using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationsSystem.Domain.Entities;

namespace ReservationsSystem.Infrastructure.Persistence.Configurations
{

    public sealed class CatalogueConfiguration : IEntityTypeConfiguration<Catalogue>
    {
        public void Configure(EntityTypeBuilder<Catalogue> builder)
        {
            builder.HasKey(catalogue => catalogue.Id);

            builder.Property(catalogue => catalogue.Name)
            .HasColumnName("name")
            .HasColumnType("nvarchar(100)")
            .IsRequired();

            builder.Property(catalogue => catalogue.Order)      
            .HasColumnName("order")
            .HasColumnType("int");

            builder.Property(catalogue => catalogue.Description)
            .HasColumnName("description")
            .HasColumnType("nvarchar(250)");

            

        }
    }   

}