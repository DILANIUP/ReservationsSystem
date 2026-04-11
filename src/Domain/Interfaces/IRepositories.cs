using ReservationsSystem.Domain.Entities;

namespace ReservationsSystem.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<User?> GetByEmailAsync(string email, CancellationToken ct = default);
        Task<bool> ExistsByEmailAsync(string email, CancellationToken ct = default);
        void Create(User user);
        void Update(User user);
    }

    public interface IAdditionalServiceRepository
    {
        Task<AdditionalService?> GetByIdAsync(Guid id, CancellationToken ct = default);
        void Create(AdditionalService additionalService);
        void Update(AdditionalService additionalService);
    }

}