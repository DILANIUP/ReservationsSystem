using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationsSystem.Domain.Entities;

namespace ReservationsSystem.Infrastructure.Persistence.Configurations
{

    public sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(user => user.Id);

            builder.Property(user => user.PasswordHash)
            .HasColumnName("password_hash")
            .HasColumnType("nvarchar(255)")
            .IsRequired();


            builder.OwnsOne(
                user => user.Email,
                email =>
                {
                    email.Property(email => email.Value)
                    .HasColumnName("value")
                    .HasColumnType("nvarchar(50)")
                    .IsRequired();
                    
                }
            );
            

            builder.HasMany(user => user.Roles)
            .WithMany(role => role.Users)
            .UsingEntity("UserRoles");

            
        }
    }   

}