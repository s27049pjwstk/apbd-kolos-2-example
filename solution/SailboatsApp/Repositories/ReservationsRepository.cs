using Microsoft.EntityFrameworkCore;
using SailboatsApp.Models.Domain;
using SailboatsApp.Persistence;
using SailboatsApp.Repositories.Abstractions;

namespace SailboatsApp.Repositories;

public class ReservationsRepository : BaseRepository, IReservationsRepository
{
    public ReservationsRepository(SailboatsDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Reservation>> GetAllClientsReservations(int idClient, CancellationToken cancellationToken)
    {
        return await _dbContext.Reservations.Where(e => e.IdClient == idClient)
            .OrderBy(e => e.DateTo).ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Reservation>> GetActiveClientsReservations(int idClient, CancellationToken cancellationToken)
    {
        return await _dbContext.Reservations.Where(e => !e.Fulfilled)
            .OrderBy(e => e.DateTo)
            .ToListAsync(cancellationToken);
    }

    public async Task AddReservationAsync(Reservation reservation, CancellationToken cancellationToken)
    {
        await _dbContext.Reservations.AddAsync(reservation, cancellationToken);
    }
}