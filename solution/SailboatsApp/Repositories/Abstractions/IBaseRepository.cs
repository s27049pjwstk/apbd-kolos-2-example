namespace SailboatsApp.Repositories.Abstractions;

public interface IBaseRepository
{
    Task SaveChangesAsync(CancellationToken cancellationToken);
}