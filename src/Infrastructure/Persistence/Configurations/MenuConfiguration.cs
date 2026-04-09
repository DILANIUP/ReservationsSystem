using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationsSystem.Domain.Entities;

namespace ReservationsSystem.Infrastructure.Persistence.Configurations
{

    public sealed class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasKey(menu => menu.Id);

            builder.Property(menu => menu.Name)
            .HasColumnName("name")
            .HasColumnType("nvarchar(100)")
            .IsRequired();

            builder.Property(menu => menu.IsActive)
            .HasColumnName("is_active")
            .HasColumnType("bit")
            .IsRequired();

            builder.Property(menu => menu.Description)
            .HasColumnName("description")
            .HasColumnType("nvarchar(100)");

            builder.HasOne(menu => menu.Category)
            .WithMany(category => category.Menus)
            .HasForeignKey(menu => menu.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(menu => menu.Restaurant)
            .WithMany(restaurant => restaurant.Menus)
            .HasForeignKey(menu => menu.Restaurant)
            .OnDelete(DeleteBehavior.Cascade);

        }

    }
}