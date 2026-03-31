using ReservationsSystem.Domain.Errors;
using ReservationsSystem.Domain.Primitives;

namespace ReservationsSystem.Domain.ValueObjects;

public sealed class ReservationSlot : IEquatable<ReservationSlot>
{
    public DateOnly Date { get; private set; }
    public TimeOnly StartTime { get; private set; }
    public TimeOnly EndTime { get; private set; }

    private ReservationSlot(DateOnly date, TimeOnly startTime, TimeOnly endTime)
    {
        Date = date;
        StartTime = startTime;
        EndTime = endTime;
    }

    // Required for EF Core owned type materialization
    private ReservationSlot()
    {
    }

    public static Result<ReservationSlot> Create(DateOnly date, TimeOnly startTime, TimeOnly endTime)
    {
        if (date <= DateOnly.FromDateTime(DateTime.Now))
            return Result.Failure<ReservationSlot>(ReservationsErrors.InvalidDate);

        if (startTime >= endTime)
            return Result.Failure<ReservationSlot>(ReservationsErrors.InvalidTimeRange);

        return new ReservationSlot(date, startTime, endTime);
    }

    public bool Equals(ReservationSlot? other) =>
        other is not null &&
        Date == other.Date &&
        StartTime == other.StartTime &&
        EndTime == other.EndTime;

    public override bool Equals(object? obj) => obj is ReservationSlot slot && Equals(slot);
    public override int GetHashCode() => HashCode.Combine(Date, StartTime, EndTime);
}