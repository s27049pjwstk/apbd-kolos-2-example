using Microsoft.EntityFrameworkCore;
using MyTry.Contexts;
using MyTry.Models;
using MyTry.Repositories;

namespace MyTry.Services;

public class ClientsService(IClientsRepository clientsRepository, IReservationsRepository reservationsRepository)
    : IClientsService {
    public async Task<ClientDto> GetClientAsync(int idClient, CancellationToken cancellationToken) {
        var client = await clientsRepository.GetClientAsync(idClient, cancellationToken);
        if (client is null) {
            throw new ArgumentException("Client does not exist!");
        }

        var reservations = await reservationsRepository.GetClientReservationsAsync(idClient, cancellationToken);
        return new ClientDto {
            IdClient = client.IdClient,
            Name = client.Name,
            LastName = client.LastName,
            Birthday = client.Birthday,
            Pesel = client.Pesel,
            Email = client.Email,
            Reservations = reservations.Select(r => new ReservationDto {
                IdReservation = r.IdReservation,
                DateFrom = r.DateFrom,
                DateTo = r.DateTo,
                Capacity = r.Capacity,
                NumOfBoats = r.NumOfBoats,
                Fulfilled = r.Fulfilled,
                Price = r.Price,
                CancelReason = r.CancelReason
            })
        };
    }
}