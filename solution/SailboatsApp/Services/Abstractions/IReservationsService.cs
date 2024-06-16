using SailboatsApp.Models.Requests;

namespace SailboatsApp.Services.Abstractions;

public interface IReservationsService
{
    Task<int> CreateReservationAsync(CreateReservationDto request, CancellationToken cancellationToken);
}