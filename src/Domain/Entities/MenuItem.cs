using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationsSystem.Domain.Entities;

public class MenuItem
{
    public Guid Id { get; set; }
    public Guid MenuId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }
    public string? ImageUrl { get; set; }
    public Catalogue? Category { get; set; }
    public Menu Menu { get; set; } = null!;
}