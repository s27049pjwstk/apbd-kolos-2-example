using SailboatsApp.Models.Domain;

namespace SailboatsApp.Repositories.Abstractions;

public interface ISailboatsRepository : IBaseRepository
{
    Task<IEnumerable<Sailboat>> GetFreeSailBoatsAsync(int level, DateOnly dateFrom, DateOnly dateTo, CancellationToken cancellationToken);
}