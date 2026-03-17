namespace ReservationsSystem.Domain.Entities;

public class Hotel
{
    public Guid Id { get; set; }
    public Guid ResourceId { get; set; }
    public required int NumRooms { get; set; }
    public required string RoomTypes { get; set; }
    public required bool HasBreakfast { get; set; }
    public Resource Resource { get; set; } = null!;
}