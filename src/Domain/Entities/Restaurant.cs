using ReservationsSystem.Domain.Errors;
using ReservationsSystem.Domain.Primitives;
using ReservationsSystem.Domain.ValueObjects;

namespace ReservationsSystem.Domain.Entities;

public class Restaurant : AuditableEntity
{
    public Guid ResourceId { get; private set; }

    public Resource Resource { get; private set; } = null!;
    public ICollection<Schedule> Schedules { get; private set; } = [];
    public ICollection<Flat> Flats { get; private set; } = [];
    public ICollection<Menu> Menus { get; private set; } = [];

    private Restaurant(Guid id, Guid resourceId) : base(id)
    {
        ResourceId = resourceId;
    }

    private Restaurant() { }

    public static Result<Restaurant> Create(Guid resourceId)
    {
        if (resourceId == Guid.Empty)
            return Result.Failure<Restaurant>(RestaurantErrors.InvalidResourceId);
        return new Restaurant(Guid.NewGuid(), resourceId);
    }
}