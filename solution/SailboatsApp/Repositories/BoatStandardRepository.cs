using Microsoft.EntityFrameworkCore;
using SailboatsApp.Models.Domain;
using SailboatsApp.Persistence;
using SailboatsApp.Repositories.Abstractions;

namespace SailboatsApp.Repositories;

public class BoatStandardRepository : BaseRepository, IBoatStandardRepository
{
    public BoatStandardRepository(SailboatsDbContext dbContext) : base(dbContext)
    {
    }

    public Task<BoatStandard?> GetBoatStandardAsync(int idBoatStandard, CancellationToken cancellationToken)
    {
        return _dbContext.BoatStandards.SingleOrDefaultAsync(e => e.IdBoatStandard == idBoatStandard);
    }
}