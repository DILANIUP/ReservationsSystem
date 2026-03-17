namespace ReservationsSystem.Domain.Entities;

public class EventVenue
{
    public Guid Id { get; set; }
    public Guid ResourceId { get; set; }
    public required int  NumTables { get; set; }
    public required int CapacityPerTable { get; set; }
    public required int NumChairs { get; set; }
    public required int SpaceM2 { get; set; }
    public required bool HasStage { get; set; }
    public Resource Resource { get; set; } = null!;
}