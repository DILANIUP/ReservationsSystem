namespace ReservationsSystem.Domain.Entities;

public class RestaurantSchedule
{
    public int Id { get; set; }
    public int RestaurantId { get; set; }
    public string DayOfWeek { get; set; }
    public TimeOnly OpenTime { get; set; }
    public TimeOnly CloseTime { get; set; }
    public bool IsOpen { get; set; }
    public Restaurant Restaurant { get; set; }
}