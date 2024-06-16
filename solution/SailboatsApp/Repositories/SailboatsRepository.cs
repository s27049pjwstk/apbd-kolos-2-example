using Microsoft.EntityFrameworkCore;
using SailboatsApp.Models.Domain;
using SailboatsApp.Persistence;
using SailboatsApp.Repositories.Abstractions;

namespace SailboatsApp.Repositories;

public class SailboatsRepository : BaseRepository, ISailboatsRepository
{
    public SailboatsRepository(SailboatsDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Sailboat>> GetFreeSailBoatsAsync(int level, DateOnly dateFrom, DateOnly dateTo, CancellationToken cancellationToken)
    {
        return await _dbContext.Sailboats
            .Include(s => s.Reservations)
            .Where(s => s.BoatStandard.Level >= level &&
                                !s.Reservations.Any(r =>
                                r.DateFrom <= dateTo && r.DateTo >= dateFrom && r.Fulfilled && r.CancelReason == null))
            .ToListAsync(cancellationToken);
    }
}