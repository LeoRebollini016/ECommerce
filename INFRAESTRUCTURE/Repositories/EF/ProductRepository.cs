using DOMAIN.Entities;
using DOMAIN.Interfaces.Repositories;
using INFRAESTRUCTURE.Context;
using Microsoft.EntityFrameworkCore;

namespace INFRAESTRUCTURE.Repositories.EF;

public class ProductRepository(ApplicationDbContext context) : IProductRepository
{
    public async Task<IEnumerable<Product>> GetProducts(CancellationToken ct)
        => await context.Products.ToListAsync(ct);
    public async Task<bool> AnyNameAsync(string name)
        => await context.Products.AnyAsync(x => x.Name == name);

    public async Task<Product?> FindByIdAsync(int id, CancellationToken ct)
        => await context.Products.FirstOrDefaultAsync(x => x.Id == id, ct);

    public async Task<bool> ExistsAsync(int id, CancellationToken ct)
        => await context.Products.AnyAsync(x => x.Id == id, ct);

    public async Task Delete(int id, CancellationToken ct)
    {
        var entity = await context.Products.FirstOrDefaultAsync(x => x.Id == id, ct);
        context.Remove(entity!);
    }
}