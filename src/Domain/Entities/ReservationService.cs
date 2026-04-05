using ReservationsSystem.Domain.Enums;
using ReservationsSystem.Domain.Errors;
using ReservationsSystem.Domain.Primitives;

namespace ReservationsSystem.Domain.Entities;

public class ReservationService : Entity
{
    public Guid ReservationId { get; set; }
    public Guid AdditionalServiceId { get; set; }
    public AdditionalServiceStatus Status { get; set; }
    public Reservation Reservation { get; set; } = null!;
    public AdditionalService AdditionalService { get; set; } = null!;

    private ReservationService(
        Guid id,
        Guid reservationId,
        Guid additionalServiceId,
        AdditionalServiceStatus status) : base(id)
    {
        ReservationId = reservationId;
        AdditionalServiceId = additionalServiceId;
        Status = status;
    }

    private ReservationService()
    {
    }

    public static Result<ReservationService> Create(
        Guid reservationId,
        Guid additionalServiceId,
        AdditionalServiceStatus status = AdditionalServiceStatus.Confirmed
    )
    {
        if (reservationId == Guid.Empty)
            return Result.Failure<ReservationService>(ReservationServiceErrors.InvalidReservationId);

        if (additionalServiceId == Guid.Empty)
            return Result.Failure<ReservationService>(ReservationServiceErrors.AdditionalServiceId);

        return new ReservationService(Guid.NewGuid(), reservationId, additionalServiceId, status);
    }

    //todo: add method update, delete
    public Result Update(AdditionalServiceStatus status)
    {
        Status = status;
        return Result.Success();
    }

    public bool IsDeleted { get; private set; }

    public Result Delete()
    {
        if (IsDeleted)
            return Result.Failure(ReservationServiceErrors.AlreadyDeleted);

        IsDeleted = true;
        return Result.Success();
    }
}