using SailboatsApp.Models.Responses;
using SailboatsApp.Repositories.Abstractions;
using SailboatsApp.Services.Abstractions;

namespace SailboatsApp.Services;

public class ClientsService : IClientsService
{
    public ClientsService(IClientsRepository clientsRepository, IReservationsRepository reservationsRepository)
    {
        ClientsRepository = clientsRepository;
        ReservationsRepository = reservationsRepository;
    }

    public IClientsRepository ClientsRepository { get; set; }
    public IReservationsRepository ReservationsRepository { get; set; }

    public async Task<ClientsReservationsResponseDto?> GetClientAsync(int idClient, CancellationToken cancellationToken)
    {
        //Fetching the data
        var client = await ClientsRepository.GetClientAsync(idClient, cancellationToken);
        if (client == null)
        {
            throw new ArgumentException("Client does not exist");
        }

        var reservations = await ReservationsRepository.GetAllClientsReservations(idClient, cancellationToken);

        //Mapping to response models
        var clientDto = new ClientsReservationsResponseDto
        {
            IdClient = client.IdClient,
            Name = client.Name,
            LastName = client.LastName,
            Birthday = client.Birthday,
            Pesel = client.Pesel,
            Email = client.Email,
            Reservations = reservations.Select(r => new ReservationDto
            {
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

        return clientDto;
    }
}