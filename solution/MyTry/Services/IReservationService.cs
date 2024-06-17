using MyTry.Models;

namespace MyTry.Services;

public interface IReservationService {
    Task<int> CreateReservationAsync(ReservationPostDto request, CancellationToken cancellationToken);
}