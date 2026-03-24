using ReservationsSystem.Domain.ValueObjects;

namespace ReservationsSystem.Domain.Entities;

public class Restaurant
{
    public Guid Id { get; set; }
    public Guid ResourceId { get; set; }
  
    public Resource Resource { get; set; } = null!;
    public ICollection<Schedule> Schedules { get; set; } = [];
    public ICollection<Flat> Flats { get; set; } = [];
    public ICollection<Menu> Menus { get; set; } = [];
}