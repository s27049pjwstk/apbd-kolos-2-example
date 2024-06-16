using SailboatsApp.Persistence;

namespace SailboatsApp.Repositories.Abstractions;

public abstract class BaseRepository : IBaseRepository
{
    protected readonly SailboatsDbContext _dbContext;

    protected BaseRepository(SailboatsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}