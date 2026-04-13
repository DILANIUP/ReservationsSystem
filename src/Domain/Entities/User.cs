using ReservationsSystem.Domain.Errors;
using ReservationsSystem.Domain.Primitives;
using ReservationsSystem.Domain.ValueObjects;

namespace ReservationsSystem.Domain.Entities;

public class User : AuditableEntity
{
    public Email Email { get; private set; } = null!;
    public string PasswordHash { get; private set; } = null!;
    public UserProfile UserProfile { get; private set; } = null!;
    public ICollection<Reservation> Reservations { get; private set; } = [];
    public ICollection<Review> Reviews { get; private set; } = [];
    public ICollection<Role> Roles { get; private set; } = [];


    private User(
        Guid id,
        Email email,
        string passwordHash
    ) : base(id)
    {
        Email = email;
        PasswordHash = passwordHash;
    }

    private User() { }

    public static Result<User> Create(
        Email email,
        string passwordHash
    )
    {
        if (string.IsNullOrWhiteSpace(passwordHash))
            return Result.Failure<User>(UserErrors.InvalidPasswordHash);

        var user = new User(Guid.NewGuid(), email, passwordHash);
        return user;
    }

    public Result UpdateEmail(Email email)
    {
        var emailResult = Email.Create(email.Value);
        if (emailResult.IsFailure)
            return Result.Failure(UserErrors.InvalidEmail);

        Email = emailResult.Value;
        return Result.Success();
    }

    public void UpdatePassword(string newPasswordHash)
    {
        PasswordHash = newPasswordHash;
    }

    //todo: agregar validaciones de contraseña 

}

