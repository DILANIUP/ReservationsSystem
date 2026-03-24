using ReservationsSystem.Domain.ValueObjects;

namespace ReservationsSystem.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public required Email Email { get; set; }
    public required string PasswordHash { get; set; }
    public required string Role { get; set; }
    public DateTime CreatedAt { get; set; }
    public UserProfile UserProfile { get; set; } = null!;
    public ICollection<Reservation> Reservations { get; set; } = [];
    public ICollection<Review> Reviews { get; set; } = []; 
    public ICollection<Role> Roles { get; set; } = new List<Role>();

}