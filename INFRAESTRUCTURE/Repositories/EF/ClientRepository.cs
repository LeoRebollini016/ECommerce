using DOMAIN.Entities;
using DOMAIN.Interfaces.Repositories;
using INFRAESTRUCTURE.Context;
using Microsoft.EntityFrameworkCore;

namespace INFRAESTRUCTURE.Repositories.EF;

public class ClientRepository(ApplicationDbContext context) : IClientRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task DeleteAsync(int id, CancellationToken ct)
    {
        var client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);
        _context.Clients.Remove(client!);
    }

    public async Task<bool> ExistsByEmailAsync(string email, CancellationToken ct)
        => await _context.Clients.AnyAsync(c => c.Email == email, ct);
    public async Task<bool> ExistsByIdAsync(int id, CancellationToken ct)
        => await _context.Clients.AnyAsync(c => c.Id == id, ct);

    public async Task<Client?> GetClientById(int id, CancellationToken cancellationToken)
    => await _context.Clients.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
}
