using ReservationsSystem.Domain.Enums;

namespace ReservationsSystem.Domain.Entities;

public class ReservationService
{
    public Guid Id { get; set; }
    public Guid ReservationId { get; set; }
    public Guid AdditionalServiceId { get; set; }
    public AdditionalServiceStatus Status { get; set; } = AdditionalServiceStatus.Confirmed; 
    public Reservation Reservation { get; set; } = null!;
    public AdditionalService AdditionalService { get; set; } = null!;
}