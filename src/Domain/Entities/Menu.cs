using ReservationsSystem.Domain.Errors;
using ReservationsSystem.Domain.Primitives;

namespace ReservationsSystem.Domain.Entities;

public class Menu : Entity
{
    public Guid RestaurantId { get; private set; }
    public Guid CategoryId { get; private set; }
    public string Name { get; private set; }
    public bool IsActive { get; private set; }
    public string? Description { get; private set; }
    public Catalogue? Category { get; private set; } = null!;
    public Restaurant Restaurant { get; private set; } = null!;
    public ICollection<MenuItem> MenuItems { get; private set; } = [];

    private Menu(
        Guid id,
        Guid restaurantId,
        Guid categoryId,
        string name,
        string? description,
        bool isActive
    ) : base(id)
    {
        RestaurantId = restaurantId;
        CategoryId = categoryId;
        Name = name;
        Description = description;
        IsActive = isActive;
    }

    public static Result<Menu> Create(
        Guid restaurantId,
        Guid categoryId,
        string name,
        string? description,
        bool isActive = true
    )
    {

        if (restaurantId == Guid.Empty)
            return Result.Failure<Menu>(MenuErrors.InvalidRestaurantId);

        if (categoryId == Guid.Empty)
            return Result.Failure<Menu>(MenuErrors.InvalidCategoryId);

        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<Menu>(MenuErrors.InvalidName);

        return new Menu(Guid.NewGuid(), restaurantId, categoryId, name.Trim(), description,isActive);
    }

    public Result Update(
        Guid restaurantId,
        Guid categoryId,
        string name,
        string? description,
        bool isActive   
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
        IsActive = isActive;

        return Result.Success();
    }
}