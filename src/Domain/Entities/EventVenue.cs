namespace ReservationsSystem.Domain.Entities;

public class EventVenue
{
    public int Id { get; set; }
    public int ResourceId { get; set; }
    public int NumTables { get; set; }
    public int CapacityPerTable { get; set; }
    public int NumChairs { get; set; }
    public int SpaceM2 { get; set; }
    public bool HasStage { get; set; }
    public Resource Resource { get; set; }
}