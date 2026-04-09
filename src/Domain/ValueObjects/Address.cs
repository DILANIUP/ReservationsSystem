

using ReservationsSystem.Domain.Primitives;

namespace ReservationsSystem.Domain.ValueObjects;

public sealed class Address : IEquatable<Address>
{
    private Address(string street, string city, string postalCode)
    {
        Street = street;
        City = city;
        PostalCode = postalCode;
    }

    private Address() { }

    public string Street { get; private set; } = default!;
    public string City { get; private set; } = default!;
    public string? PostalCode { get; private set; } = default!;

    public static Result<Address> Create(string street, string city, string? postalCode)
    {
        if (string.IsNullOrWhiteSpace(street))
            return Result.Failure<Address>(new Error("Address.EmptyStreet", "Street cannot be empty."));
        if (string.IsNullOrWhiteSpace(city))
            return Result.Failure<Address>(new Error("Address.EmptyCity", "City cannot be empty."));

        return new Address(street.Trim(), city.Trim(), postalCode.Trim());
    }

    public bool Equals(Address? other) =>
        other is not null &&
        Street == other.Street &&
        City == other.City &&
        PostalCode == other.PostalCode;

    public override bool Equals(object? obj) => obj is Address address && Equals(address);
    public override int GetHashCode() => HashCode.Combine(Street, City, PostalCode);
    public override string ToString() => $"{Street}, {City}, {PostalCode}";
}