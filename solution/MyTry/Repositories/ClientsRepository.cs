using Microsoft.EntityFrameworkCore;
using MyTry.Contexts;
using MyTry.Models;

namespace MyTry.Repositories;

public class ClientsRepository(S27049DbContext _dbContext) : IClientsRepository {
    public async Task<Client?> GetClientAsync(int idClient, CancellationToken cancellationToken) {
        return await _dbContext.Clients.Include(c => c.ClientCategory)
            .SingleOrDefaultAsync(c => c.IdClient == idClient, cancellationToken);
    }
}