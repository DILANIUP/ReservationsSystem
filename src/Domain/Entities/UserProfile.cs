using ReservationsSystem.Domain.Errors;
using ReservationsSystem.Domain.Primitives;
using ReservationsSystem.Domain.ValueObjects;

namespace ReservationsSystem.Domain.Entities;

public class UserProfile : AuditableEntity
{
    public Guid UserId { get; private set; }
    public string FullName { get; private set; } = null!;
    public string? Phone { get; private set; }
    public  string IdentificationNumber { get; private set; } = null!;
    public  string IdentificationType { get; private set; } = null!;
    public  Address? Address { get; private set; } = null!;
    public User User { get; private set; } = null!;

    private UserProfile(
        Guid id,
        Guid userId,
        string fullName,
        string? phone,
        string identificationNumber,
        string identificationType,
        Address? address
    ) : base(id)
    {
        UserId = userId;
        FullName = fullName;
        Phone = phone;
        IdentificationNumber = identificationNumber;
        IdentificationType = identificationType;
        Address = address;
    }

    private UserProfile() { }

    public static Result<UserProfile> Create(
        Guid userId,
        string fullName,
        string? phone,
        string identificationNumber,
        string identificationType,
        Address? address
    )

    {
        if (string.IsNullOrWhiteSpace(fullName))
            return Result.Failure<UserProfile>(UserProfileErrors.InvalidFullName);
        
        if (string.IsNullOrWhiteSpace(identificationNumber))
            return Result.Failure<UserProfile>(UserProfileErrors.InvalidIdentificationNumber);
        
        if (string.IsNullOrWhiteSpace(identificationType))
            return Result.Failure<UserProfile>(UserProfileErrors.InvalidIdentificationType);

        var userProfile = new UserProfile(Guid.NewGuid(), userId, fullName, phone, identificationNumber, identificationType, address);
        return userProfile;
    }

    public Result Update(
        string fullName,
        string? phone,
        string identificationNumber,
        string identificationType,
        Address address
    )
    {
        if (string.IsNullOrWhiteSpace(fullName))
            return Result.Failure(UserProfileErrors.InvalidFullName);
        
        if (string.IsNullOrWhiteSpace(identificationNumber))
            return Result.Failure(UserProfileErrors.InvalidIdentificationNumber);
        
        if (string.IsNullOrWhiteSpace(identificationType))
            return Result.Failure(UserProfileErrors.InvalidIdentificationType);
        //todo: validar address y value objects en general en el dominio de cada entidad o en los servicios antes de pasar la data

        FullName = fullName.Trim();
        Phone = phone;
        IdentificationNumber = identificationNumber;
        IdentificationType = identificationType;
        Address = address;

        return Result.Success();
    }
}