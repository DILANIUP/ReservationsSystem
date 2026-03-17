namespace ReservationsSystem.Domain.Entities;

public class Restaurant
{
    public Guid Id { get; set; }
    public Guid ResourceId { get; set; }
    public required string Phone { get; set; }
    public required string Email { get; set; }
    public string? Website { get; set; }
    public Resource Resource { get; set; } = null!;
    public ICollection<Schedule> Schedules { get; set; } = [];
    public ICollection<Flat> Flats { get; set; } = [];
    public ICollection<Menu> Menus { get; set; } = [];
}