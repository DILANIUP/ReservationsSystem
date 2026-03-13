namespace ReservationsSystem.Domain.Entities;

public class MenuCategory
{
    public int Id { get; set; }
    public int RestaurantId { get; set; }
    public string Name { get; set; }
    public int DisplayOrder { get; set; }
    public Restaurant Restaurant { get; set; }
    public List<MenuItem> MenuItems { get; set; }
}