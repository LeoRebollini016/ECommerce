using DOMAIN.Interfaces.Repositories;
using DOMAIN.Interfaces.Services;

namespace APPLICATION.Services.Client;

public class ClientService(IClientRepository _clientRepository, ICommandGenerics _command) : IClientService
{
    public async Task<IEnumerable<DOMAIN.Entities.Client>> GetAllAsync(CancellationToken ct)
        => await _command.GetAllAsync<DOMAIN.Entities.Client>(ct);

    public async Task<DOMAIN.Entities.Client?> GetClientById(int id, CancellationToken cancellationToken)
        => await _clientRepository.GetClientById(id, cancellationToken);
    public async Task AddAsync(DOMAIN.Entities.Client entity, CancellationToken ct)
    {
        await _command.AddAsync(entity, ct);
        await _command.SaveChangeAsync(ct);

    }
    public async Task Update(DOMAIN.Entities.Client entity, CancellationToken ct)
    {
        _command.Update(entity);
        await _command.SaveChangeAsync(ct);
    }

    public async Task Delete(int id, CancellationToken ct)
    { 
        await _clientRepository.DeleteAsync(id, ct);
        await _command.SaveChangeAsync(ct);
    }

    public async Task<bool> ExistsByEmailAsync(string email, CancellationToken ct)
        => await _clientRepository.ExistsByEmailAsync(email, ct);

    public async Task<bool> ExistsByIdAsync(int id, CancellationToken ct)
        => await _clientRepository.ExistsByIdAsync(id, ct);
}
