
using ReservationsSystem.Domain.Primitives;

namespace ReservationsSystem.Domain.Entities
{
    public class RefreshToken : Entity
    {
        public Guid UserId { get; private set; }
        public string Token { get; private set; } = null!;
        public DateTime ExpiresOnUtc { get; private set; }
        public bool IsExpired => DateTime.UtcNow >= ExpiresOnUtc;

        private RefreshToken(Guid id, Guid userId, string token, DateTime expiresOnUtc) : base(id)
        {
            UserId = userId;
            Token = token;
            ExpiresOnUtc = expiresOnUtc;
        }

        private RefreshToken() { }

        public static RefreshToken Create(Guid userId, string token, DateTime expiresOnUtc)
        {
            return new RefreshToken(Guid.NewGuid(), userId, token, expiresOnUtc);
        }
    }
}