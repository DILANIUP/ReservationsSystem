namespace ReservationsSystem.Domain.Entities;

public class Hotel
{
    public int Id { get; set; }
    public int ResourceId { get; set; }
    public int NumRooms { get; set; }
    public string RoomTypes { get; set; }
    public bool HasBreakfast { get; set; }
    public Resource Resource { get; set; }
}