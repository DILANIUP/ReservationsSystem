namespace ReservationsSystem.Application.Features.Auth;

public sealed record RegisterRequest(
    string Email,
    string Password,
    string Fullname,
    string IdentificationNumber,
    string IdentificationType,
    string? Phone,
    string? Street,
    string? City,
    string? Country
);

public sealed record RegisterResponse(
    Guid UserId,
    string Email,
    string Fullname
);

public sealed record LoginRequest(
    string Email,
    string Password);