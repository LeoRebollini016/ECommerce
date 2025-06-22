using DOMAIN.Entities;

namespace DOMAIN.Interfaces.Services;

public interface IClientService
{
    public Task<IEnumerable<Client>> GetAllAsync(CancellationToken ct);
    public Task<Client?> GetClientById(int id, CancellationToken ct);
    public Task AddAsync(Client entity, CancellationToken ct);
    public Task Update(Client entity, CancellationToken ct);
    public Task Delete(int id, CancellationToken ct);
    public Task<bool> ExistsByIdAsync(int id, CancellationToken ct);
    public Task<bool> ExistsByEmailAsync(string email, CancellationToken ct);
}
