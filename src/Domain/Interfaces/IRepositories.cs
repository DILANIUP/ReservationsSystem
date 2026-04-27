using ReservationsSystem.Domain.Entities;

namespace ReservationsSystem.Domain.Interfaces
{
    public interface IRepository
    {
        Task<User?> GetByIdAsync(Guid id, CancellationToken ct = default);
        void Add(User user);
        // void Update(User user);
    }
    public interface IUserRepository : IRepository
    {
        // Task<User?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<User?> GetByEmailAsync(string email, CancellationToken ct = default);
        Task<bool> ExistsByEmailAsync(string email, CancellationToken ct = default);
        // void Add(User user);
        void Update(User user);
    }

    public interface IUserProfileRepository
    {
        Task<UserProfile?> GetByUserIdAsync(Guid userId, CancellationToken ct = default);
        void Create(UserProfile userProfile);
    }

    public interface IRefreshTokenRepository
    {
        Task<RefreshToken?> GetByTokenAsync(string token, CancellationToken ct = default);
        void Create(RefreshToken refreshToken);
        void Delete(RefreshToken refreshToken);
    }


    public interface IAdditionalServiceRepository
    {
        Task<AdditionalService?> GetByIdAsync(Guid id, CancellationToken ct = default);
        void Create(AdditionalService additionalService);
        void Update(AdditionalService additionalService);
    }

    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken ct = default);
    }


}