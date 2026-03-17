namespace ReservationsSystem.Domain.Entities;

public class UserProfile
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public required string FullName { get; set; }
    public string? Phone { get; set; }
    public required string IdentificationNumber { get; set; }
    public required string IdentificationType { get; set; }
    public required string Address { get; set; }
    public required string City { get; set; }
    public User User { get; set; } = null!;
}