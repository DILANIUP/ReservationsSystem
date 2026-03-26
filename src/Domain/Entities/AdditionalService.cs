using System.ComponentModel.DataAnnotations.Schema;
using ReservationsSystem.Domain.Errors;
using ReservationsSystem.Domain.Primitives;
using ReservationsSystem.Domain.ValueObjects;

namespace ReservationsSystem.Domain.Entities;

public class AdditionalService : AuditableEntity
{
    public Guid ResourceId { get; private set; }
    public string Name { get; private set; } = null!;
    public string? Description { get; private set; }
    public Money? Price { get; private set; }
    public bool IsFree { get; private set; }
    public Resource Resource { get; private set; } = null!;
    public ICollection<ReservationService> ReservationServices { get; set; } = [];// porque por definicion es una coleccion vacia, no es nula

    private AdditionalService(
        Guid id,
        Guid resourceId,
        string name,
        string? description,
        Money? price,
        bool isFree
    ) : base(id)
    {
        ResourceId = resourceId;
        Name = name;
        Description = description;
        Price = price;
        IsFree = isFree;
    }

    // Constructor privado para EF Core
    private AdditionalService() { }

    public static Result<AdditionalService> Create(
        Guid resourceId,
        string name,
        string? description,
        Money? price,
        bool isFree
    )
    {
        if (isFree && price is not null)
            return Result.Failure<AdditionalService>(AdditionalServiceErrors.InvalidPriceForFreeService);

        if (!isFree && price is null)
            return Result.Failure<AdditionalService>(AdditionalServiceErrors.InvalidPriceForPaidService);

        if (price is not null)
        {
            var moneyResult = Money.Create(price.Amount, price.Currency);
            if (moneyResult.IsFailure)
                return Result.Failure<AdditionalService>(moneyResult.Error);
        }

        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<AdditionalService>(AdditionalServiceErrors.InvalidName);

        var additionalService = new AdditionalService(Guid.NewGuid(), resourceId, name.Trim(), description, price, isFree);
        return additionalService;
    }


    public Result Update(
        string? name,
        string? description,
        Money? price,
        bool? isFree
    )
    {
        if (isFree.HasValue && isFree.Value)
        {
            Price = null;
            IsFree = true;
        }


        if (isFree.HasValue && isFree.Value == false)
        {
            var effectivePrice = price ?? Price; //!important: tiene la opcion de escoger una de las dos opciones en la variable
            if (effectivePrice is null)
                return Result.Failure(AdditionalServiceErrors.InvalidPriceForPaidService);

            var moneyResult = Money.Create(effectivePrice.Amount, effectivePrice.Currency);
            if (moneyResult.IsFailure)
                return Result.Failure(moneyResult.Error);

            Price = effectivePrice;
            IsFree = false;
        }


        if (!string.IsNullOrWhiteSpace(name))
            Name = name.Trim();

        if (description is not null)
            Description = description;


        return Result.Success();
    }


}