using ReservationsSystem.Domain.Errors;
using ReservationsSystem.Domain.Primitives;

namespace ReservationsSystem.Domain.Entities;

public class Menu : AuditableEntity
{
    public Guid RestaurantId { get; private set; }
    public Guid CategoryId { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public Catalogue? Category { get; private set; } = null!;
    public Restaurant Restaurant { get; private set; } = null!;
    public ICollection<MenuItem> MenuItems { get; private set; } = [];

    private Menu(
        Guid id,
        Guid restaurantId,
        Guid categoryId,
        string name,
        string? description
    ) : base(id)
    {
        RestaurantId = restaurantId;
        CategoryId = categoryId;
        Name = name;
        Description = description;
    }

    public static Result<Menu> Create(
        Guid restaurantId,
        Guid categoryId,
        string name,
        string? description
    )
    {

        if (restaurantId == Guid.Empty)
            return Result.Failure<Menu>(MenuErrors.InvalidRestaurantId);

        if (categoryId == Guid.Empty)
            return Result.Failure<Menu>(MenuErrors.InvalidCategoryId);

        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<Menu>(MenuErrors.InvalidName);

        return new Menu(Guid.NewGuid(), restaurantId, categoryId, name.Trim(), description);
    }

    public Result Update(
        Guid restaurantId,
        Guid categoryId,
        string name,
        string? description
    )
    {

        if (restaurantId == Guid.Empty)
            return Result.Failure<Menu>(MenuErrors.InvalidRestaurantId);

        if (categoryId == Guid.Empty)
            return Result.Failure<Menu>(MenuErrors.InvalidCategoryId);

        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<Menu>(MenuErrors.InvalidName);

        RestaurantId = restaurantId;
        CategoryId = categoryId;
        Name = name.Trim();
        Description = description;

        return Result.Success();
    }
}