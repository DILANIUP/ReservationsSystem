namespace ReservationsSystem.Domain.Entities;

public class Schedule
{
    public Guid Id { get; set; }
    public Guid ResourceId { get; set; }
    public TimeOnly OpenTime { get; set; }
    public TimeOnly CloseTime { get; set; }
    public Resource Resource { get; set; } = null!;
    public ICollection<Catalogue> DaysOfWeek { get; set; } = [];
}

