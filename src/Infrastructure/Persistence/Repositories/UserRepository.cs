using Microsoft.EntityFrameworkCore;
using ReservationsSystem.Domain.Entities;
using ReservationsSystem.Domain.Interfaces;
using ReservationsSystem.Infrastructure.Data;

public sealed class UserRepository(AppDbContext db) : IUserRepository
{

    public void Add(User user) => db.Users.Add(user);

    public async Task<bool> ExistsByEmailAsync(string email, CancellationToken ct = default) =>
        await db.Users.AnyAsync(u => u.Email.Value == email, ct);

    public async Task<User?> GetByEmailAsync(string email, CancellationToken ct = default) =>
        await db.Users
        .Include(u => u.Roles)
        .FirstOrDefaultAsync(u => u.Email.Value == email, ct);

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        await db.Users
        .Include(u => u.Roles)
        .FirstOrDefaultAsync(u => u.Id == id, ct);

    public void Update(User user) => db.Users.Update(user);
}