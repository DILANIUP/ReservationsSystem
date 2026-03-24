using ReservationsSystem.Domain.Enums;
using ReservationsSystem.Domain.ValueObjects;
namespace ReservationsSystem.Domain.Entities;

public class Reservation
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ResourceId { get; set; }
    public required DateOnly ReservationDate { get; set; }
    public required TimeOnly StartTime { get; set; }
    public required TimeOnly EndTime { get; set; }

    public required Money TotalAmount { get; set; } = null!;
    public required Money? AdvancedPayment { get; set; }

    public required int GuestCount { get; set; }
    public ReservationStatus Status { get; set; } = ReservationStatus.Pending; //todo: no pedir en el formulario el estado viene por defecto
    public string? SpecialRequests { get; set; }
    public DateTime CreatedAt { get; set; }
    public User User { get; set; } = null!;
    public Resource Resource { get; set; } = null!;
    public Review? Review { get; set; } = null!;
    public ICollection<ReservationService> ReservationServices { get; set; } = [];
}