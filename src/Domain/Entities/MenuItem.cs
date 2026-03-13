using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationsSystem.Domain.Entities;

public class MenuItem
{
    public int Id { get; set; }
    public int MenuCategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }
    public string ImageUrl { get; set; }
    public MenuCategory MenuCategory { get; set; }
}