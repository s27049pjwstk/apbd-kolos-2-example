using Microsoft.EntityFrameworkCore;
using SailboatsApp.Models.Domain;
using SailboatsApp.Persistence;
using SailboatsApp.Repositories.Abstractions;

namespace SailboatsApp.Repositories;

public class ClientsRepository : BaseRepository, IClientsRepository
{
    public ClientsRepository(SailboatsDbContext dbContext) : base(dbContext)
    {
    }

    public Task<Client?> GetClientAsync(int idClient, CancellationToken cancellationToken)
    {
        return _dbContext.Clients.Include(c => c.Category).SingleOrDefaultAsync(c => c.IdClient == idClient, cancellationToken);
    }
}