using DOMAIN.Entities;

namespace DOMAIN.Interfaces.Repositories;

public interface IClientRepository
{
    public Task<Client?> GetClientById(int id, CancellationToken cancellationToken);
    public Task DeleteAsync(int id, CancellationToken ct);
    public Task<bool> ExistsByEmailAsync(string email, CancellationToken ct);
    public Task<bool> ExistsByIdAsync(int id, CancellationToken ct);
}
