namespace ReservationsSystem.Domain.Entities;

public class Menu
{
    public Guid Id { get; set; }
    public Guid RestaurantId { get; set; }
    public Guid CategoryId { get; set; }
    public required string Name { get; set; }
    public string? description;
    public Catalogue? Category { get; set; } = null!;
    public Restaurant Restaurant { get; set; } = null!;
    public ICollection<MenuItem> MenuItems { get; set; } = [];
}