using DOMAIN.Interfaces;
using INFRAESTRUCTURE.Context;

namespace INFRAESTRUCTURE.Repositories.EF;

public class CommandGenerics(ApplicationDbContext context) : ICommandGenerics
{
    private readonly ApplicationDbContext _context = context;
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
