using ReservationsSystem.Domain.Entities;

namespace ReservationsSystem.Infrastructure.Authentication;

public interface ITokenService
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken();
}
