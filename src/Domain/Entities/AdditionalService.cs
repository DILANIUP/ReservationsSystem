using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationsSystem.Domain.Entities;

public class AdditionalService
{
    public int Id { get; set; }
    public int ResourceId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }
    public bool IsFree { get; set; }
    public Resource Resource { get; set; }
    public List<ReservationService> ReservationServices { get; set; }
}