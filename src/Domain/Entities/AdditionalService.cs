namespace ReservationsSystem.Domain.Entities;

public class AdditionalService
{
    public int Id { get; set; }
    public int ResourceId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public bool IsFree { get; set; }
    public Resource Resource { get; set; }
    public List<ReservationService> ReservationServices { get; set; }
}