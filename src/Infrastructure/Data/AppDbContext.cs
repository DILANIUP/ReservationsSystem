using Microsoft.EntityFrameworkCore;
using ReservationsSystem.Domain.Entities;
using ReservationsSystem.Domain.Primitives;

namespace ReservationsSystem.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
        public DbSet<AdditionalService> AdditionalServices { get; set; }
        public DbSet<Catalogue> Catalogues { get; set; }
        public DbSet<EventVenue> EventVenues { get; set; }
        public DbSet<ExceptionDate> ExceptionDates { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationService> ReservationServices { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateAuditFields();
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }

        private void UpdateAuditFields()
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.Now;
                        break;
                }
            }
        }
    }
}
