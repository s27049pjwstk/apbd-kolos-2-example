using Microsoft.EntityFrameworkCore;
using MyTry.Contexts;
using MyTry.Models;

namespace MyTry.Repositories;

public class ReservationsRepository(S27049DbContext dbContext) : IReservationsRepository {
    public async Task<IEnumerable<Reservation>?> GetClientReservationsAsync(int idClient, CancellationToken cancellationToken) {
        return await dbContext.Reservations.Where(e => e.IdClient == idClient).OrderByDescending(e => e.DateTo).ToListAsync();
    }

    public async Task<bool> CheckClientAnyActiveReservationsAsync(int idClient,
        CancellationToken cancellationToken) {
        return await dbContext.Reservations.AnyAsync(
            e => e.IdClient == idClient && !e.Fulfilled && e.CancelReason == null,
            cancellationToken: cancellationToken);
    }
}