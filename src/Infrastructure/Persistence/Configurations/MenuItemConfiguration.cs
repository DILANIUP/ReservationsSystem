using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationsSystem.Domain.Entities;

namespace ReservationsSystem.Infrastructure.Persistence.Configurations
{

    public sealed class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.HasKey(menuItem => menuItem.Id);

            builder.Property(menuItem => menuItem.Name)
            .HasColumnName("name")
            .HasColumnType("nvarchar(100)")
            .IsRequired();

            builder.Property(menuItem => menuItem.Description)
            .HasColumnName("description")
            .HasColumnType("nvarchar(250)");

            builder.OwnsOne(menu => menu.Price, price =>
            {
                price.Property(p => p.Amount)
                .HasColumnName("amount")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

                price.Property(p => p.Currency)
                .HasColumnName("currency")
                .HasColumnType("char(3)")
                .IsRequired();


            });

            builder.Property(menuItem => menuItem.IsAvailable)
            .HasColumnName("is_available")
            .HasColumnType("bit")
            .IsRequired();

            builder.Property(menuItem => menuItem.ImageUrl)
            .HasColumnName("image_url")
            .HasColumnType("nvarchar(500)");

            builder.HasOne(menuItem => menuItem.Category)
            // .WithMany(category => category.MenuItems)
            .WithMany() //!important: Se cambio a WithMany sin parametros para evitar la navegacion inversa, ya que no se tiene una coleccion de MenuItems en Category
            .HasForeignKey(menuItem => menuItem.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(menuItem => menuItem.Menu)
            .WithMany(menu => menu.MenuItems)
            .HasForeignKey(menuItem => menuItem.MenuId)
            .OnDelete(DeleteBehavior.Cascade);

        }

    }
}