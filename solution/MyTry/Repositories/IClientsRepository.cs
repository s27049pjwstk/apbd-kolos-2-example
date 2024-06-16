using MyTry.Models;

namespace MyTry.Repositories;

public interface IClientsRepository {
    Task<Client?> GetClientAsync(int idClient, CancellationToken cancellationToken);
}