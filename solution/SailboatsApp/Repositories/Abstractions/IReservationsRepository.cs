using SailboatsApp.Models.Domain;

namespace SailboatsApp.Repositories.Abstractions;

public interface IReservationsRepository : IBaseRepository
{
    public Task<IEnumerable<Reservation>> GetAllClientsReservations(int idClient, CancellationToken cancellationToken);
    public Task<IEnumerable<Reservation>> GetActiveClientsReservations(int idClient, CancellationToken cancellationToken);
    public Task AddReservationAsync(Reservation reservation, CancellationToken cancellationToken);
}