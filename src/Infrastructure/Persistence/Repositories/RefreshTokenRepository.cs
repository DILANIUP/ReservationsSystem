using Microsoft.EntityFrameworkCore;
using ReservationsSystem.Domain.Entities;
using ReservationsSystem.Domain.Interfaces;
using ReservationsSystem.Infrastructure.Data;

public sealed class RefreshTokenRepository(AppDbContext db) : IRefreshTokenRepository
{
    public async Task<RefreshToken?> GetByTokenAsync(string token, CancellationToken ct = default) =>
        await db.RefreshTokens.FirstOrDefaultAsync(rt => rt.Token == token, ct);

    public void Create(RefreshToken refreshToken) => db.RefreshTokens.Add(refreshToken);

    public void Delete(RefreshToken refreshToken) => db.RefreshTokens.Remove(refreshToken);
}