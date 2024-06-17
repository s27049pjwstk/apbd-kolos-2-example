using MyTry.Models;
using MyTry.Repositories;

namespace MyTry.Services;

public class ReservationService(IClientsRepository clientsRepository, IReservationsRepository reservationsRepository)
    : IReservationService {
    public async Task<int> CreateReservationAsync(ReservationPostDto request, CancellationToken cancellationToken) {
        var client = await clientsRepository.GetClientAsync(request.IdClient, cancellationToken);
        if (client == null) throw new ArgumentException("Client does not exist!");

        var reservation = new Reservation {
            IdClient = request.IdClient,
            DateFrom = request.DateFrom,
            DateTo = request.DateTo,
            IdBoatStandard = request.IdBoatStandard,
        };

        if (await reservationsRepository.CheckClientAnyActiveReservationsAsync(request.IdClient, cancellationToken)) {
            reservation.CancelReason = "Client already has an active reservation";
        }

        throw new NotImplementedException();
    }
}