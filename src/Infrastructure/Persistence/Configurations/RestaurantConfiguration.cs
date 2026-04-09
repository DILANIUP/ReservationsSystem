using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationsSystem.Domain.Entities;

namespace ReservationsSystem.Infrastructure.Persistence.Configurations
{

    public sealed class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.HasKey(restaurants => restaurants.Id);
            
            builder.HasOne(restaurant => restaurant.Resource)     
                .WithOne(resource => resource.Restaurant)      
                .HasForeignKey<Restaurant>(restaurant => restaurant.ResourceId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }   

}