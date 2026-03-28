using ReservationsSystem.Domain.Errors;
using ReservationsSystem.Domain.Primitives;

namespace ReservationsSystem.Domain.Entities;

public class Review : AuditableEntity
{
    public Guid UserId { get; set; }
    public Guid ResourceId { get; set; }
    public Guid ReservationId { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public DateTime CreatedAt { get; set; }
    public User User { get; set; } = null!;
    public Resource Resource { get; set; } = null!;
    public Reservation Reservation { get; set; } = null!;

    private Review(
        Guid id,
        Guid userId,
        Guid resourceId,
        Guid reservationId,
        int rating,
        string? comment
    ) : base(id)
    {
        UserId = userId;
        ResourceId = resourceId;
        ReservationId = reservationId;
        Rating = rating;
        Comment = comment;
    }

    private Review() { }

    public static Result<Review> Create(
        Guid userId,
        Guid resourceId,
        Guid reservationId,
        int rating,
        string? comment
    )
    {
        if (rating < 1 || rating > 5)
            return Result.Failure<Review>(ReviewErrors.InvalidRating);
        var review = new Review(Guid.NewGuid(), userId, resourceId, reservationId, rating, comment);
            return review;
    }

    public Result Update(
        int rating,
        string? comment
    )
    {
        if (rating < 1 || rating > 5)
            return Result.Failure(ReviewErrors.InvalidRating);

        Rating = rating;
        Comment = comment;

        return Result.Success();
    }

    
    
}