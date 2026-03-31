using ReservationsSystem.Domain.Enums;
using ReservationsSystem.Domain.Errors;
using ReservationsSystem.Domain.Primitives;
using ReservationsSystem.Domain.ValueObjects;

namespace ReservationsSystem.Domain.Entities;

public class Resource : AuditableEntity
{
    public Guid? RestaurantId { get; private set; }
    public Guid? HotelId { get; private set; }
    public Guid? EventVenueId { get; private set; }
    public string Name { get; private set; }
    public string Phone { get; private set; }
    public Email Email { get; private set; }
    public string? Website { get; private set; }
    public string? Description { get; private set; }
    public Address Address { get; private set; }
    public ResourceType Type { get; private set; } // tipo de establecimiento -lo que oferta 
    public bool IsActive { get; private set; }
    
    //navigation
    public Restaurant? Restaurant { get; private set; }
    public Hotel? Hotel { get; private set; }
    public EventVenue? EventVenue { get; private set; }
    public ICollection<AdditionalService> AdditionalServices { get; private set; } = [];
    public ICollection<Reservation> Reservations { get; private set; } = [];
    public ICollection<Review> Reviews { get; private set; } = [];
    public ICollection<ExceptionDate> ExceptionDates { get; private set; } = [];

    private Resource(
        Guid id,
        Guid? restaurantId,
        Guid? hotelId,
        Guid? eventVenueId,
        string name,
        string phone,
        Email email,
        string? website,
        string? description,
        Address address,
        ResourceType type,
        bool isActive
    ) : base(id)
    {
        RestaurantId = restaurantId;
        HotelId = hotelId;
        EventVenueId = eventVenueId;
        Name = name;
        Phone = phone;
        Email = email;
        Website = website;
        Description = description;
        Address = address;
        Type = type;
        IsActive = isActive;
    }

    private Resource()
    {
    }

    public static Result<Resource> Create(
        Guid? restaurantId,
        Guid? hotelId,
        Guid? eventVenueId,
        string name,
        string phone,
        Email email,
        string? website,
        string? description,
        Address address,
        ResourceType type,
        bool isActive)
    {
        if ( restaurantId == Guid.Empty)
            return Result.Failure<Resource>(ResourceErrors.InvalidRestaurantId);

        if ( hotelId == Guid.Empty)
            return Result.Failure<Resource>(ResourceErrors.InvalidHotelId);

        if ( eventVenueId == Guid.Empty)
            return Result.Failure<Resource>(ResourceErrors.InvalidEventVenueId);

        var ownerCount = new[] { restaurantId, hotelId, eventVenueId }
            .Count(id => id.HasValue);

        if (ownerCount > 1)
            return Result.Failure<Resource>(ResourceErrors.MultipleOwnerEntities);

        if (ownerCount == 0)
            return Result.Failure<Resource>(ResourceErrors.NoOwnerEntity);

        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<Resource>(ResourceErrors.InvalidName);

        if (string.IsNullOrWhiteSpace(phone))
            return Result.Failure<Resource>(ResourceErrors.InvalidPhone);
        
        return new Resource(Guid.NewGuid(), restaurantId, hotelId, eventVenueId, name, phone, email, website,
            description, address, type, isActive);
    }
    
    public Result Update(
        string name,
        string phone,
        Email email,
        string? website,
        string? description,
        Address address,
        ResourceType type)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure(ResourceErrors.InvalidName);

        if (string.IsNullOrWhiteSpace(phone))
            return Result.Failure(ResourceErrors.InvalidPhone);

        Name = name;
        Phone = phone;
        Email = email;
        Website = website;
        Description = description;
        Address = address;
        Type = type;

        return Result.Success();
    }
    public Result Activate()
    {
        if (IsActive)
            return Result.Failure(ResourceErrors.AlreadyActive);

        IsActive = true;
        return Result.Success();
    }

    public Result Deactivate()
    {
        if (!IsActive)
            return Result.Failure(ResourceErrors.AlreadyInactive);

        IsActive = false;
        return Result.Success();
    }
    
    //todo: comentar si vamos a mantener que el resource pueda tener una sola entidad que pertenece
}