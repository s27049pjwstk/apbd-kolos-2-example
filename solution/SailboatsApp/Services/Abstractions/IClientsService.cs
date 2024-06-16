using SailboatsApp.Models.Responses;

namespace SailboatsApp.Services.Abstractions;

public interface IClientsService
{
    Task<ClientsReservationsResponseDto?> GetClientAsync(int idClient, CancellationToken cancellationToken);
}