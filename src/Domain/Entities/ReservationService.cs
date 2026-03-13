namespace ReservationsSystem.Domain.Entities;

public class ReservationService
{
    public int Id { get; set; }
    public int ReservationId { get; set; }
    public int AdditionalServiceId { get; set; }
    public int Quantity { get; set; }
    public Reservation Reservation { get; set; }
    public AdditionalService AdditionalService { get; set; }
}