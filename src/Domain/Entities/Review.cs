namespace ReservationsSystem.Domain.Entities;

public class Review
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ResourceId { get; set; }
    public Guid ReservationId { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public DateTime CreatedAt { get; set; }
    public User User { get; set; } = null!;
    public Resource Resource { get; set; } = null!;
    public Reservation Reservation { get; set; } = null!;
}