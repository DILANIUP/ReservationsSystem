namespace ReservationsSystem.Domain.Entities;

public class Resource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Type { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public Restaurant Restaurant { get; set; }
    public Hotel Hotel { get; set; }
    public EventVenue EventVenue { get; set; }
    public List<AdditionalService> AdditionalServices { get; set; }
    public List<Reservation> Reservations { get; set; }
    public List<Review> Reviews { get; set; }
}