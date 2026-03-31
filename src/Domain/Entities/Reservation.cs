using ReservationsSystem.Domain.Enums;
using ReservationsSystem.Domain.Errors;
using ReservationsSystem.Domain.Primitives;
using ReservationsSystem.Domain.ValueObjects;

namespace ReservationsSystem.Domain.Entities;

public class Reservation : AuditableEntity
{
    public Guid UserId { get; private set; }
    public Guid ResourceId { get; private set; }
    public ReservationSlot ReservationSlot { get; private set; } = null!;

    public Money TotalAmount { get; private set; } = null!;
    public Money? AdvancedPayment { get; private set; }
    public int GuestCount { get; private set; }
    public ReservationStatus Status { get; private set; }
    public string? SpecialRequests { get; private set; }
    public User User { get; private set; } = null!;
    public Resource Resource { get; private set; } = null!;
    public Review? Review { get; private set; } = null!;
    public ICollection<ReservationService> ReservationServices { get; private set; } = [];

    private Reservation(
        Guid id,
        Guid userId,
        Guid resourceId,
        ReservationSlot reservationSlot,
        Money totalAmount,
        int guestCount
    ) : base(id)
    {
        UserId = userId;
        ResourceId = resourceId;
        ReservationSlot = reservationSlot;
        TotalAmount = totalAmount;
        GuestCount = guestCount;
        Status = ReservationStatus.Pending;
    }

    private Reservation()
    {
    }

    public static Result<Reservation> Create(
        Guid userId,
        Guid resourceId,
        ReservationSlot reservationSlot,
        Money totalAmount,
        Money? advancedPayment,
        int guestCount,
        string? specialRequests
    )
    {
        if (userId == Guid.Empty)
            return Result.Failure<Reservation>(ReservationsErrors.InvalidUserId);

        if (resourceId == Guid.Empty)
            return Result.Failure<Reservation>(ReservationsErrors.InvalidResourceId);

        if (reservationSlot is null)
            return Result.Failure<Reservation>(ReservationsErrors.InvalidReservationSlot);

        if (totalAmount is null)
            return Result.Failure<Reservation>(ReservationsErrors.InvalidTotalAmount);

        if (guestCount <= 0)
            return Result.Failure<Reservation>(ReservationsErrors.InvalidGuestCount);

        if (advancedPayment is not null)
        {
            if (advancedPayment.Currency != totalAmount.Currency)
                return Result.Failure<Reservation>(ReservationsErrors.InvalidAdvancedPayment);

            if (advancedPayment.Amount > totalAmount.Amount)
                return Result.Failure<Reservation>(ReservationsErrors.InvalidAdvancedPayment);
        }

        var reservation = new Reservation(
            Guid.NewGuid(),
            userId,
            resourceId,
            reservationSlot,
            totalAmount,
            guestCount);

        reservation.AdvancedPayment = advancedPayment;
        reservation.SpecialRequests = specialRequests;

        return reservation;
    }

    public Result Update(
        ReservationSlot reservationSlot,
        Money totalAmount,
        Money? advancedPayment,
        int guestCount,
        string? specialRequests
    )
    {
        if (reservationSlot is null)
            return Result.Failure<Reservation>(ReservationsErrors.InvalidReservationSlot);

        if (totalAmount is null)
            return Result.Failure<Reservation>(ReservationsErrors.InvalidTotalAmount);

        if (guestCount <= 0)
            return Result.Failure<Reservation>(ReservationsErrors.InvalidGuestCount);

        if (advancedPayment is not null)
        {
            if (advancedPayment.Currency != totalAmount.Currency)
                return Result.Failure<Reservation>(ReservationsErrors.InvalidAdvancedPayment);

            if (advancedPayment.Amount > totalAmount.Amount)
                return Result.Failure<Reservation>(ReservationsErrors.InvalidAdvancedPayment);
        }

        ReservationSlot = reservationSlot;
        TotalAmount = totalAmount;
        AdvancedPayment = advancedPayment;
        GuestCount = guestCount;
        SpecialRequests = specialRequests;

        return Result.Success();
    }

    public Result Cancel()
    {
        if (Status == ReservationStatus.Cancelled)
            return Result.Failure<Reservation>(ReservationsErrors.AlreadyCancelled);

        if (Status is ReservationStatus.Completed or ReservationStatus.Rejected)
            return Result.Failure<Reservation>(ReservationsErrors.CannotCancelFinalizedReservation);

        Status = ReservationStatus.Cancelled;
        return Result.Success();
    }

    public Result Confirm()
    {
        if (Status == ReservationStatus.Confirmed)
            return Result.Failure<Reservation>(ReservationsErrors.AlreadyConfirmed);

        if (Status != ReservationStatus.Pending)
            return Result.Failure<Reservation>(ReservationsErrors.CannotConfirmReservation);

        Status = ReservationStatus.Confirmed;
        return Result.Success();
    }

    public Result Complete()
    {
        if (Status == ReservationStatus.Completed)
            return Result.Failure<Reservation>(ReservationsErrors.AlreadyCompleted);

        if (Status != ReservationStatus.Confirmed)
            return Result.Failure<Reservation>(ReservationsErrors.CannotCompleteReservation);

        Status = ReservationStatus.Completed;
        return Result.Success();
    }

    public Result Reject()
    {
        if (Status == ReservationStatus.Rejected)
            return Result.Failure<Reservation>(ReservationsErrors.AlreadyRejected);

        if (Status != ReservationStatus.Pending)
            return Result.Failure<Reservation>(ReservationsErrors.CannotRejectReservation);

        Status = ReservationStatus.Rejected;
        return Result.Success();
    }
}