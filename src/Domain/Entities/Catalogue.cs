using Microsoft.EntityFrameworkCore;
using ReservationsSystem.Domain.Errors;
using ReservationsSystem.Domain.Primitives;

namespace ReservationsSystem.Domain.Entities;

public class Catalogue : Entity
{
    public string Name { get; private set; } = null!;
    public int? Order { get; private set; }
    public string? Description { get; private set; }

    private Catalogue(
        Guid id,
        string name,
        int? order,
        string? description
    ) : base(id)
    {
        Name = name;
        Order = order;
        Description = description;
    }
    private Catalogue() { }

    public static Result<Catalogue> Create(
        string name,
        int? order,
        string? description
    )
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<Catalogue>(CatalogueErrors.InvalidName);

        var catalogue = new Catalogue(Guid.NewGuid(), name.Trim(), order, description);
        return catalogue;
    }

    public Result Update(
        string name,
        int? order,
        string? description
    )
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure(CatalogueErrors.InvalidName);

        Name = name.Trim();
        Order = order;
        Description = description;

        return Result.Success();
    }
}