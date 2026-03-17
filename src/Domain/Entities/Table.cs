namespace ReservationsSystem.Domain.Entities;

public class Table
{
    public Guid Id { get; set; }
    public Guid FlatId { get; set; }
    public int TableNumber { get; set; }
    public required int Capacity { get; set; }
    public required string Location { get; set; }
    public bool IsActive { get; set; }
    public Flat Flat { get; set; } = null!;
}