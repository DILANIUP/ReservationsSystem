using ReservationsSystem.Domain.Errors;
using ReservationsSystem.Domain.Primitives;

namespace ReservationsSystem.Domain.Entities;

public class UserProfile : AuditableEntity
{
    public Guid UserId { get; private set; }
    public string FullName { get; private set; } = null!;
    public string? Phone { get; private set; }
    public  string IdentificationNumber { get; private set; } = null!;
    public  string IdentificationType { get; private set; } = null!;
    public  string Address { get; private set; } = null!;
    public  string City { get; private set; } = null!;
    public User User { get; private set; } = null!;

    private UserProfile(
        Guid id,
        Guid userId,
        string fullName,
        string? phone,
        string identificationNumber,
        string identificationType,
        string address,
        string city
    ) : base(id)
    {
        UserId = userId;
        FullName = fullName;
        Phone = phone;
        IdentificationNumber = identificationNumber;
        IdentificationType = identificationType;
        Address = address;
        City = city;
    }

    private UserProfile() { }

    public static Result<UserProfile> Create(
        Guid userId,
        string fullName,
        string? phone,
        string identificationNumber,
        string identificationType,
        string address,
        string city
    )
    {
        if (string.IsNullOrWhiteSpace(fullName))
            return Result.Failure<UserProfile>(UserProfileErrors.InvalidFullName);
        
        if (string.IsNullOrWhiteSpace(identificationNumber))
            return Result.Failure<UserProfile>(UserProfileErrors.InvalidIdentificationNumber);
        
        if (string.IsNullOrWhiteSpace(identificationType))
            return Result.Failure<UserProfile>(UserProfileErrors.InvalidIdentificationType);
        
        if (string.IsNullOrWhiteSpace(address))
            return Result.Failure<UserProfile>(UserProfileErrors.InvalidAddress);
        
        if (string.IsNullOrWhiteSpace(city))
            return Result.Failure<UserProfile>(UserProfileErrors.InvalidCity);

        var userProfile = new UserProfile(Guid.NewGuid(), userId, fullName, phone, identificationNumber, identificationType, address, city);
        return userProfile;
    }

    public Result Update(
        string fullName,
        string? phone,
        string identificationNumber,
        string identificationType,
        string address,
        string city
    )
    {
        if (string.IsNullOrWhiteSpace(fullName))
            return Result.Failure(UserProfileErrors.InvalidFullName);
        
        if (string.IsNullOrWhiteSpace(identificationNumber))
            return Result.Failure(UserProfileErrors.InvalidIdentificationNumber);
        
        if (string.IsNullOrWhiteSpace(identificationType))
            return Result.Failure(UserProfileErrors.InvalidIdentificationType);
        
        if (string.IsNullOrWhiteSpace(address))
            return Result.Failure(UserProfileErrors.InvalidAddress);
        
        if (string.IsNullOrWhiteSpace(city))
            return Result.Failure(UserProfileErrors.InvalidCity);

        FullName = fullName.Trim();
        Phone = phone;
        IdentificationNumber = identificationNumber;
        IdentificationType = identificationType;
        Address = address.Trim();
        City = city.Trim();

        return Result.Success();
    }
}