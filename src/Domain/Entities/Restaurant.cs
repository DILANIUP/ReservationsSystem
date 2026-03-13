namespace ReservationsSystem.Domain.Entities;

public class Restaurant
{
    public int Id { get; set; }
    public int ResourceId { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
    public bool ParkingAvailable { get; set; }
    public Resource Resource { get; set; }
    public List<RestaurantSchedule> Schedules { get; set; }
    public List<Table> Tables { get; set; }
    public List<MenuCategory> MenuCategories { get; set; }
}