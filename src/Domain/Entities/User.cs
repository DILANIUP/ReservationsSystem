namespace ReservationsSystem.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Role { get; set; }
    public DateTime CreatedAt { get; set; }
    public UserProfile UserProfile { get; set; }
    public List<Reservation> Reservations { get; set; }
    public List<Review> Reviews { get; set; }
}