using ReservationsSystem.Domain.Entities;

namespace ReservationsSystem.Infrastructure.Authentication;

public interface IPasswordHasher
{
    string Hash(string password);
    bool Verify(string password, string hash);
}
