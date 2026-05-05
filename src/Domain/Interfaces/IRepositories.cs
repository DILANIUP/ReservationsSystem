using ReservationsSystem.Domain.Entities;

namespace ReservationsSystem.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id, CancellationToken ct = default);
        void Add(T entity);
        // void Update(User user);
    }
    public interface IUserRepository : IRepository<User>
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
        void Add(UserProfile userProfile);
    }

    public interface IRefreshTokenRepository
    {
        Task<RefreshToken?> GetByTokenAsync(string token, CancellationToken ct = default);
        void Add(RefreshToken refreshToken);
        void Delete(RefreshToken refreshToken);
    }


    public interface IAdditionalServiceRepository
    {
        Task<AdditionalService?> GetByIdAsync(Guid id, CancellationToken ct = default);
        void Add(AdditionalService additionalService);
        void Update(AdditionalService additionalService);
    }

    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken ct = default);
    }


}