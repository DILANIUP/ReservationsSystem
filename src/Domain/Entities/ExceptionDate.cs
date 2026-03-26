using ReservationsSystem.Domain.Errors;
using ReservationsSystem.Domain.Primitives;

namespace ReservationsSystem.Domain.Entities;

public class ExceptionDate : Entity
{
    public Guid ResourceId { get; set; }
    public DateOnly Date { get; set; }
    public string? Reason { get; set; }
    public Resource Resource { get; set; } = null!;

    private ExceptionDate(
        Guid id,
        Guid resourceId,
        DateOnly date,
        string? reason
    ) : base(id)
    {
        ResourceId = resourceId;
        Date = date;
        Reason = reason;
    }

    private ExceptionDate() { }

    public static Result<ExceptionDate> Create(
        Guid resourceId,
        DateOnly date,
        string? reason)
    {
        if (resourceId == Guid.Empty)
            return Result.Failure<ExceptionDate>(ExceptionDateErrors.InvalidResourceId);

        if (date < DateOnly.FromDateTime(DateTime.Now))
            return Result.Failure<ExceptionDate>(ExceptionDateErrors.InvalidDate);

        return new ExceptionDate(Guid.NewGuid(), resourceId, date, reason);
    }

    public Result Update(Guid resourceId, DateOnly date, string? reason)
    {
        if (resourceId == Guid.Empty)
            return Result.Failure<ExceptionDate>(ExceptionDateErrors.InvalidResourceId);

        if (date < DateOnly.FromDateTime(DateTime.Now))
            return Result.Failure<ExceptionDate>(ExceptionDateErrors.InvalidDate);


        ResourceId = resourceId;
        Date = date;
        Reason = reason;

        return Result.Success();
    }
}