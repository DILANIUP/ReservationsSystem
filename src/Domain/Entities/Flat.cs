using ReservationsSystem.Domain.Errors;
using ReservationsSystem.Domain.Primitives;

namespace ReservationsSystem.Domain.Entities;

public class Flat : Entity
{
    public Guid Id { get; set; }
    public Guid RestaurantId { get; set; }
    public int FlatNumber { get; set; }
    public bool IsActive { get; set; }
    public Restaurant Restaurant { get; set; } = null!;
    public ICollection<Table> Tables { get; set; } = [];

    private Flat(
        Guid id,
        Guid restaurantId,
        int flatNumber,
        bool isActive
    ) : base(id)
     {
        Id = id;
        RestaurantId = restaurantId;
        FlatNumber = flatNumber;
        IsActive = isActive;
    }
    
    private Flat(){}

    public static Result<Flat> Create(
        Guid id,
        Guid restaurantId,
        int flatNumber,
        bool isActive
    )
    {
        if (restaurantId == Guid.Empty)
            return Result.Failure<Flat>(FlatErrors.InvalidRestaurantId);
        
        if(flatNumber <= 0)
            return Result.Failure<Flat>(FlatErrors.InvalidFlatNumber);
        
        var flat = new Flat(Guid.NewGuid(), restaurantId, flatNumber, isActive);
        return flat;
    }

    public Result Update(
        Guid restaurantId,
        int flatNumber,
        bool isActive
    )
    {
        if (restaurantId == Guid.Empty)
            return Result.Failure(FlatErrors.InvalidRestaurantId);
        
        if(flatNumber <= 0)
            return Result.Failure(FlatErrors.InvalidFlatNumber);

        RestaurantId = restaurantId;
        FlatNumber = flatNumber;
        isActive = isActive;

        return Result.Success();    
    }
    
}