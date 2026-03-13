namespace ReservationsSystem.Domain.Entities;

public class Table
{
    public int Id { get; set; }
    public int RestaurantId { get; set; }
    public int TableNumber { get; set; }
    public int Capacity { get; set; }
    public string Location { get; set; }
    public bool IsActive { get; set; }
    public Restaurant Restaurant { get; set; }
}