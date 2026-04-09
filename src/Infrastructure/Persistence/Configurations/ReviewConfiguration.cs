using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationsSystem.Domain.Entities;

namespace ReservationsSystem.Infrastructure.Persistence.Configurations
{

    public sealed class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(review => review.Id);

            builder.Property(review => review.Rating)
            .HasColumnName("rating")
            .HasColumnType("int")
            .IsRequired();

            builder.Property(review => review.Comment)
            .HasColumnName("comment")
            .HasColumnType("nvarchar(250)");

            builder.HasOne(review => review.User)       
                .WithMany(user => user.Reviews)          
                .HasForeignKey(review => review.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(review => review.Resource)       
                .WithMany(resource => resource.Reviews)          
                .HasForeignKey(review => review.ResourceId)
                .OnDelete(DeleteBehavior.NoAction);
            
            

        }
    }   

}