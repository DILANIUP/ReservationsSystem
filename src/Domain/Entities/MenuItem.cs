using System.ComponentModel.DataAnnotations.Schema;
using ReservationsSystem.Domain.Errors;
using ReservationsSystem.Domain.Primitives;
using ReservationsSystem.Domain.ValueObjects;

namespace ReservationsSystem.Domain.Entities;

public class MenuItem: AuditableEntity
{
    public Guid MenuId { get; private set; }
    public Guid? CategoryId { get; private set; }
    public string Name { get; private set; } = null!;
    public string? Description { get; private set; }
    public Money Price { get; private set; } = null!;
    public bool IsAvailable { get; private set; }
    public string? ImageUrl { get; private set; }

    // navigation
    public Catalogue? Category { get; private set; }
    public Menu Menu { get; private set; }

    private MenuItem(
        Guid id,
        Guid menuId,
        Guid? categoryId,
        string name,
        string? description,
        Money price,
        string? imageUrl,
        bool isAvailable = true
    ):base(id)
    {
        MenuId = menuId;
        CategoryId = categoryId;
        Name = name;
        Description = description;
        Price = price;
        IsAvailable = isAvailable;
        ImageUrl = imageUrl;
    }

    private MenuItem() {}

    public static Result<MenuItem> Create(
        Guid menuId,
        Guid? categoryId,
        string name,
        string? description,
        Money price,
        string? imageUrl,
        bool isAvailable = true
    )
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<MenuItem>(MenuItemErrors.InvalidName);

        return new MenuItem(Guid.NewGuid(), menuId, categoryId, name, description, price, imageUrl, isAvailable);
    }
}