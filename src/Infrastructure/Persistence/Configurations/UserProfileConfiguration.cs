using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationsSystem.Domain.Entities;

namespace ReservationsSystem.Infrastructure.Persistence.Configurations
{

    public sealed class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasKey(userProfile => userProfile.Id);

            builder.Property(userProfile => userProfile.FullName)
            .HasColumnName("full_name")
            .HasColumnType("nvarchar(100)")
            .IsRequired();

            builder.Property(userProfile => userProfile.Phone)
            .HasColumnName("phone")
            .HasColumnType("nvarchar(15)"); 

            builder.Property(userProfile => userProfile.IdentificationNumber)
            .HasColumnName("identification_number")
            .HasColumnType("nvarchar(10)")
            .IsRequired();

            builder.Property(userProfile => userProfile.IdentificationType)
            .HasColumnName("identification_type")
            .HasColumnType("nvarchar(20)")
            .IsRequired();

            builder.OwnsOne(
                userProfile => userProfile.Address,
                addres =>
                {
                    addres.Property(addres => addres.City)
                    .HasColumnName("city")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();

                    addres.Property(addres => addres.Street)
                    .HasColumnName("street")
                    .HasColumnType("nvarchar(100)")
                    .IsRequired();      
                    
                }
            );
            
            builder.HasOne(userProfile => userProfile.User)
            .WithOne(user => user.UserProfile)
            .HasForeignKey<UserProfile>(userProfile => userProfile.UserId)
            .OnDelete(DeleteBehavior.Cascade);
            
            

        }
    }   

}