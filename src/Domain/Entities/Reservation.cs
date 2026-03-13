namespace ReservationsSystem.Domain.Entities;

public class Reservation
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ResourceId { get; set; }
    public DateOnly ReservationDate { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public int GuestCount { get; set; }
    public string Status { get; set; }
    public string SpecialRequests { get; set; }
    public DateTime CreatedAt { get; set; }
    public User User { get; set; }
    public Resource Resource { get; set; }
    public Review Review { get; set; }
    public List<ReservationService> ReservationServices { get; set; }
}