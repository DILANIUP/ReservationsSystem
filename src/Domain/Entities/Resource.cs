using System.Security.AccessControl;

namespace ReservationsSystem.Domain.Entities;

public class Resource
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required string Address { get; set; }
    public required string City { get; set; }
    public required ResourceType Type { get; set; }
    public bool IsActive { get; set; } = true;
    public required DateTime CreatedAt { get; set; }
    public Restaurant? Restaurant { get; set; }
    public Hotel? Hotel { get; set; }
    public EventVenue? EventVenue { get; set; }
    public ICollection<AdditionalService> AdditionalServices { get; set; } = [];
    public ICollection<Reservation> Reservations { get; set; } = [];
    public ICollection<Review> Reviews { get; set; } = [];
    public ICollection<ExceptionDate> ExceptionDates { get; set; } = [];
}