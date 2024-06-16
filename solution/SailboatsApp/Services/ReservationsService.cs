using SailboatsApp.Models.Domain;
using SailboatsApp.Models.Requests;
using SailboatsApp.Repositories.Abstractions;
using SailboatsApp.Services.Abstractions;

namespace SailboatsApp.Services;

public class ReservationsService : IReservationsService
{
    private readonly IBoatStandardRepository _boatStandardRepository;
    private readonly IClientsRepository _clientsRepository;
    private readonly IReservationsRepository _reservationsRepository;
    private readonly ISailboatsRepository _sailboatsRepository;

    public ReservationsService(IReservationsRepository reservationsRepository, IClientsRepository clientsRepository,
        ISailboatsRepository sailboatsRepository, IBoatStandardRepository boatStandardRepository)
    {
        _reservationsRepository = reservationsRepository;
        _clientsRepository = clientsRepository;
        _sailboatsRepository = sailboatsRepository;
        _boatStandardRepository = boatStandardRepository;
    }

    public async Task<int> CreateReservationAsync(CreateReservationDto request, CancellationToken cancellationToken)
    {
        ValidateRequestDateRange(request);

        var client = await GetClientAsync(request, cancellationToken);
        var boatStandard = await GetBoatStandardAsync(request, cancellationToken);

        var newReservation = new Reservation
        {
            IdClient = request.IdClient,
            DateFrom = DateOnly.FromDateTime(request.DateFrom),
            DateTo = DateOnly.FromDateTime(request.DateTo),
            IdBoatStandard = request.IdBoatStandard,
            Fulfilled = true
        };

        await EnsureClientHasNoActiveReservations(request, newReservation, cancellationToken);
        
        var freeSailboats =
            await _sailboatsRepository.GetFreeSailBoatsAsync(boatStandard.Level, newReservation.DateFrom,
                newReservation.DateTo, cancellationToken);

        var enoughFreeBoats = CheckIfWeHaveEnoughFreeBoats(request, freeSailboats, newReservation);

        if (!enoughFreeBoats)
        {
            newReservation.CancelReason = "Not enough boats";
            await _reservationsRepository.AddReservationAsync(newReservation, cancellationToken);
            await _reservationsRepository.SaveChangesAsync(cancellationToken);
            return newReservation.IdReservation;
        }

        newReservation.Price = CalculateFinalPrice(request, freeSailboats, client);
        AssignFreeBoatsToReservation(request, freeSailboats, newReservation);
        await _reservationsRepository.AddReservationAsync(newReservation, cancellationToken);
        await _reservationsRepository.SaveChangesAsync(cancellationToken);
        
        return newReservation.IdReservation;
    }

    private static void AssignFreeBoatsToReservation(CreateReservationDto request, IEnumerable<Sailboat> freeSailboats,
        Reservation newReservation)
    {
        foreach (var boat in freeSailboats.Take(request.NumOfBoats)) newReservation.AssignedSailboats.Add(boat);
    }

    private static decimal CalculateFinalPrice(CreateReservationDto request, IEnumerable<Sailboat> freeSailboats,
        Client client)
    {
        var price = freeSailboats.Take(request.NumOfBoats)
            .Sum(e => e.Price);
        return price - price * client.Category.DiscountDec;
    }

    private static bool CheckIfWeHaveEnoughFreeBoats(CreateReservationDto request, IEnumerable<Sailboat> freeSailboats,
        Reservation newReservation)
    {
        return freeSailboats.Count() >= request.NumOfBoats;
    }

    private async Task EnsureClientHasNoActiveReservations(CreateReservationDto request, Reservation newReservation, CancellationToken cancellationToken)
    {
        var activeReservations = await _reservationsRepository.GetActiveClientsReservations(request.IdClient, cancellationToken);
        if (activeReservations.Any())
            newReservation.CancelReason = "Client already has an active reservation";
    }

    private async Task<BoatStandard> GetBoatStandardAsync(CreateReservationDto request, CancellationToken cancellationToken)
    {
        var boatStandard = await _boatStandardRepository.GetBoatStandardAsync(request.IdBoatStandard, cancellationToken);
        if (boatStandard == null) throw new ArgumentException("Boat standard does not exist");

        return boatStandard;
    }

    private async Task<Client> GetClientAsync(CreateReservationDto request, CancellationToken cancellationToken)
    {
        var client = await _clientsRepository.GetClientAsync(request.IdClient, cancellationToken);
        if (client == null) throw new ArgumentException("Client does not exist");

        return client;
    }

    private static void ValidateRequestDateRange(CreateReservationDto request)
    {
        if (request.DateFrom > request.DateTo) throw new ArgumentException("Date to has to precede date from");
    }
}