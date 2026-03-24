using System.Text.RegularExpressions;
using ReservationsSystem.Domain.Primitives;

namespace ReservationsSystem.Domain.ValueObjects;

public sealed class Email : IEquatable<Email>
{
    private static readonly Regex EmailRegex = new(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    public const int MaxLength = 254;

    private Email(string value)
    {
        Value = value;
    }

    //Required for Ef Core owned entity
    private Email() { }

    public string Value { get; private set; } = null!;

    public static Result<Email> Create(string? email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return Result.Failure<Email>(new Error("Email.Empty", "Email cannot be empty."));


        email = email.Trim().ToLowerInvariant();

        if (email.Length > MaxLength)
            return Result.Failure<Email>(new Error("Email.TooLong", $"Email cannot exceed {MaxLength} characters."));

        if (!EmailRegex.IsMatch(email))
            return Result.Failure<Email>(new Error("Email.InvalidFormat", $"Email format is invalid."));

        return new Email(email);

    }

    public bool Equals(Email? other) => other is not null && Value == other.Value;
    public override bool Equals(object? obj) => obj is Email email && Equals(email);
    public override int GetHashCode() => Value.GetHashCode();
    public override string ToString() => Value;

    // Implicit conversion to string for easier usage
    public static implicit operator string(Email email) => email.Value;
}