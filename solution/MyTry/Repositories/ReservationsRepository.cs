using Microsoft.EntityFrameworkCore;
using MyTry.Contexts;
using MyTry.Models;

namespace MyTry.Repositories;

public class ReservationsRepository(S27049DbContext dbContext) : IReservationsRepository {
    public async Task<IEnumerable<Reservation>?> GetReservationByClientIdAsync(int idClient, CancellationToken cancellationToken) {
        return await dbContext.Reservations.Where(e => e.IdClient == idClient).OrderByDescending(e => e.DateTo).ToListAsync();
    }
}