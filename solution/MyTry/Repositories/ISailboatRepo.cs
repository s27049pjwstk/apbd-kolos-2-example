using MyTry.Models;

namespace MyTry.Repositories;

public interface ISailboatRepo {
    Task<int> CountFreeSailboatsAsync(int boatLevel, CancellationToken cancellationToken);
}