namespace ReservationsSystem.Domain.Entities;

public class Flat
{
    public Guid Id { get; set; }
    public Guid RestaurantId { get; set; }
    public int FlatNumber { get; set; }
    public bool IsActive { get; set; }
    public Restaurant Restaurant { get; set; } = null!;
    public ICollection<Table> Tables { get; set; } = [];
}