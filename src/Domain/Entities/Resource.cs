using System.Security.AccessControl;
using ReservationsSystem.Domain.ValueObjects;

namespace ReservationsSystem.Domain.Entities;

public class Resource
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Phone { get; set; }
    public required Email Email { get; set; }
    public string? Website { get; set; }
    public string? Description { get; set; }
    public required Address Address { get; set; }
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