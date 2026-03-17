using Microsoft.EntityFrameworkCore;
using ReservationsSystem.Domain.Entities;

namespace ReservationsSystem.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<AdditionalService> AdditionalServices { get; set; }
        public DbSet<ReservationService> ReservationServices { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<Catalogue> Catalogues { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<EventVenue> EventVenues { get; set; }
        public DbSet<ExceptionDate> ExceptionDates { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ReservationService
            modelBuilder.Entity<ReservationService>()
                .HasOne(x => x.Reservation)
                .WithMany(x => x.ReservationServices)
                .HasForeignKey(x => x.ReservationId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ReservationService>()
                .HasOne(x => x.AdditionalService)
                .WithMany(x => x.ReservationServices)
                .HasForeignKey(x => x.AdditionalServiceId)
                .OnDelete(DeleteBehavior.NoAction);

            // Review
            modelBuilder.Entity<Review>()
                .HasOne(x => x.Reservation)
                .WithOne(x => x.Review)
                .HasForeignKey<Review>(x => x.ReservationId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Review>()
                .HasOne(x => x.Resource)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.ResourceId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Review>()
                .HasOne(x => x.User)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
