using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationsSystem.Domain.Entities;

namespace ReservationsSystem.Infrastructure.Persistence.Configurations
{

    public sealed class EventVenueConfiguration : IEntityTypeConfiguration<EventVenue>
    {
        public void Configure(EntityTypeBuilder<EventVenue> builder)
        {
            builder.HasKey(eventVenue => eventVenue.Id);
            
            builder.HasOne(eventVenue => eventVenue.Resource)     
                .WithOne(resource => resource.EventVenue)      
                .HasForeignKey<EventVenue>(eventVenue => eventVenue.ResourceId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }   

}