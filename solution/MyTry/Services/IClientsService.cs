using MyTry.Models;

namespace MyTry.Services;

public interface IClientsService {
    Task<ClientDto> GetClientAsync(int idClient, CancellationToken cancellationToken);
}