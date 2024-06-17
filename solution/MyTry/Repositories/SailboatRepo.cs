using Microsoft.EntityFrameworkCore;
using MyTry.Contexts;
using MyTry.Models;

namespace MyTry.Repositories;

public class SailboatRepo(S27049DbContext dbContext) : ISailboatRepo {
    public async Task<int> CountFreeSailboatsAsync(int boatLevel, CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}