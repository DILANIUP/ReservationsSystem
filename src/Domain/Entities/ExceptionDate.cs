namespace ReservationsSystem.Domain.Entities;
public class ExceptionDate
{
    public Guid Id { get; set; }
    public Guid ResourceId { get; set; }
    public DateOnly Date { get; set; }
    public string? Reason { get; set; }
    public Resource Resource { get; set; } = null!;     
}