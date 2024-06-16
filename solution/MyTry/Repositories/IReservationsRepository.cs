using MyTry.Models;

namespace MyTry.Repositories;

public interface IReservationsRepository {
    Task<IEnumerable<Reservation>?> GetReservationByClientIdAsync(int idClient, CancellationToken cancellationToken);
}