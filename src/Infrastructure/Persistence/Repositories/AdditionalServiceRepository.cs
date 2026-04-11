
using ReservationsSystem.Domain.Entities;
using ReservationsSystem.Domain.Interfaces;
using ReservationsSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ReservationsSystem.Infrastructure.Persistence.Repositories
{

    public class AdditionalServiceRepository : IAdditionalServiceRepository
    {
        private readonly AppDbContext _db;
        public AdditionalServiceRepository(AppDbContext db) => _db = db;

        public async Task<AdditionalService?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
             await _db.AdditionalServices.FirstOrDefaultAsync(additionalService => additionalService.Id == id, ct);


        public void Create(AdditionalService additionalService) =>
             _db.AdditionalServices.Add(additionalService);


        public void Update(AdditionalService additionalService) =>
            _db.AdditionalServices.Update(additionalService);

    }
}