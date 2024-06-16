using SailboatsApp.Models.Domain;

namespace SailboatsApp.Repositories.Abstractions;

public interface IClientsRepository : IBaseRepository
{
    public Task<Client?> GetClientAsync(int idClient, CancellationToken cancellationToken);
}