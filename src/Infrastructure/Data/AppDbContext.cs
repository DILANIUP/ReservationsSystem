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
        public DbSet<RestaurantSchedule> RestaurantSchedules { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<MenuCategory> MenuCategories { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<EventVenue> EventVenues { get; set; }
    }
}
