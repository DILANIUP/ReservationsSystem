using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationsSystem.Domain.Entities;

public class AdditionalService
{
    public Guid Id { get; set; }
    public Guid ResourceId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public Money? Price { get; set; }
    public required bool IsFree { get; set; }
    public Resource Resource { get; set; } = null!;
    public ICollection<ReservationService> ReservationServices { get; set; } = [];
}