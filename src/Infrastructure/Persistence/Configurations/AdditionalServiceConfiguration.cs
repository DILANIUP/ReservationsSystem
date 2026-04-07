
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationsSystem.Domain.Entities;

namespace ReservationsSystem.Infrastructure.Persistence.Configurations
{

    public sealed class AdditionalServiceConfiguration : IEntityTypeConfiguration<AdditionalService>
    {

        public void Configure(EntityTypeBuilder<AdditionalService> builder)
        {
            builder.HasKey(additionalService => additionalService.Id);

            builder.Property(additionalService => additionalService.Name)
            .HasColumnName("name")
            .HasColumnType("nvarchar(150)")
            .IsRequired();

            builder.Property(additionalService => additionalService.Description)
            .HasColumnName("description")
            .HasColumnType("nvarchar(250)");

            builder.OwnsOne(
                additionalService => additionalService.Price,
                money =>
                {
                    money.Property(additionalService => additionalService.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

                    money.Property(additionalService => additionalService.Currency)
                    .HasColumnName("currency")
                    .HasMaxLength(3)
                    .IsRequired();
                }
            );

            builder.Property(additionalService => additionalService.IsFree)
            .HasColumnName("isFree")
            .HasColumnType("bit")
            .IsRequired();

            // builder.HasOne(additionalService => additionalService.Resource)
            // .WithMany(resource =>)


        }
    }

}