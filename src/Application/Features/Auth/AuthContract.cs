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
    string? PostalCode);

public sealed record RegisterResponse(
    Guid UserId,
    string Email,
    string Fullname
);

public sealed record LoginRequest(
    string Email,
    string Password);

public sealed record LoginResponse(
Guid UserId,
string AccessToken,
string RefreshToken);

public sealed record RefreshTokenRequest(
    string RefreshToken);

public sealed record RefreshTokenResponse(
    string AccessToken,
    string RefreshToken);