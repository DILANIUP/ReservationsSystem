using ReservationsSystem.Domain.Errors;
using ReservationsSystem.Domain.Primitives;

namespace ReservationsSystem.Domain.Entities;

public class Schedule : Entity
{
    public Guid ResourceId { get; private set; }
    public TimeOnly OpenTime { get; private set; }
    public TimeOnly CloseTime { get; private set; }
    public Resource Resource { get; set; } = null!;
    public ICollection<Catalogue> DaysOfWeek { get; set; } = [];


    private Schedule(
        Guid id,    
        Guid resourceId,
        TimeOnly openTime,
        TimeOnly closeTime
    ) : base(id)
    {
        ResourceId = resourceId;
        OpenTime = openTime;
        CloseTime = closeTime;
    }

    private Schedule() { }

    public static Result<Schedule> Create(
        Guid resourceId,
        TimeOnly openTime,
        TimeOnly closeTime
    )
    {
        if (resourceId == Guid.Empty)
            return Result.Failure<Schedule>(ScheduleErrors.InvalidResourceId);
        if (openTime >= closeTime)
            return Result.Failure<Schedule>(ScheduleErrors.InvalidTimeRange);
        
        var schedule = new Schedule(Guid.NewGuid(), resourceId, openTime, closeTime);
        return schedule;
    }

    public Result Update(
        TimeOnly openTime,
        TimeOnly closeTime
    )
    {
        if (openTime >= closeTime)
            return Result.Failure(ScheduleErrors.InvalidTimeRange);

        OpenTime = openTime;
        CloseTime = closeTime;
        return Result.Success();
    }
    
}

