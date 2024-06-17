using MyTry.Models;

namespace MyTry.Repositories;

public interface IReservationsRepository {
    Task<IEnumerable<Reservation>?> GetClientReservationsAsync(int idClient, CancellationToken cancellationToken);

    Task<bool> CheckClientAnyActiveReservationsAsync(int idClient, CancellationToken cancellationToken);
}