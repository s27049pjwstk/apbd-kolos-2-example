using SailboatsApp.Models.Domain;

namespace SailboatsApp.Repositories.Abstractions;

public interface IBoatStandardRepository : IBaseRepository
{
    Task<BoatStandard?> GetBoatStandardAsync(int idBoatStandard, CancellationToken cancellationToken);
}