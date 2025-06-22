using DOMAIN.Entities;

namespace DOMAIN.Interfaces.Services;

public interface IProductService
{
    public Task AddAsync(Product Product, CancellationToken ct);
    public Task Update(Product newProduct, CancellationToken ct);
    public Task<IEnumerable<Product>> GetProducts(CancellationToken ct);
    public Task<Product?> FindByIdAsync(int id, CancellationToken ct);
    public Task Delete(int id, CancellationToken ct);
}