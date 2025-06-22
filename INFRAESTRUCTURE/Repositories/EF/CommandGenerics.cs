using DOMAIN.Interfaces.Repositories;
using INFRAESTRUCTURE.Context;
using Microsoft.EntityFrameworkCore;

namespace INFRAESTRUCTURE.Repositories.EF;

public class CommandGenerics(ApplicationDbContext context) : ICommandGenerics
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<T>> GetAllAsync<T>(CancellationToken ct) where T : class
    {
        return await _context.Set<T>().ToListAsync(ct);
    }
    public async Task AddAsync<T>(T entity, CancellationToken ct) where T : class
        => await _context.Set<T>().AddAsync(entity, ct);

    public async Task SaveChangeAsync(CancellationToken ct)
    => await _context.SaveChangesAsync(ct);

    public void Update<T>(T entity) where T : class
    {
        _context.Attach(entity);
        _context.Update(entity);
    }
}
