﻿using Microsoft.EntityFrameworkCore;
using MyTry.Contexts;
using MyTry.Models;

namespace MyTry.Repositories;

public class ClientsRepository(S27049DbContext dbContext) : IClientsRepository {
    public async Task<Client?> GetClientAsync(int idClient, CancellationToken cancellationToken) {
        return await dbContext.Clients.SingleOrDefaultAsync(e => e.IdClient == idClient, cancellationToken);
    }
}