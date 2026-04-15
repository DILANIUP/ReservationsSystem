using Microsoft.EntityFrameworkCore;
using ReservationsSystem.Domain.Entities;
using ReservationsSystem.Domain.Interfaces;
using ReservationsSystem.Infrastructure.Data;

public sealed class UserProfileRepository(AppDbContext db) : IUserProfileRepository
{
    public void Create(UserProfile userProfile)
    {
        db.UserProfiles.Add(userProfile);
    }

    public async Task<UserProfile?> GetByUserIdAsync(Guid userId, CancellationToken ct = default)
    {
        return await db.UserProfiles.FirstOrDefaultAsync(up => up.User.Id == userId, ct);
    }
}