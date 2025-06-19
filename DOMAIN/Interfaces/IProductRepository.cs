using DOMAIN.Entities;

namespace DOMAIN.Interfaces;

public interface IProductRepository
{
    public Task<IEnumerable<Product>> GetProducts(CancellationToken ct);
    public Task<bool> AnyNameAsync(string name);
    public Task Create(Product product);
    public Task<Product?> FindByIdAsync(int id, CancellationToken ct);
    public Task<bool> ExistsAsync(int id, CancellationToken ct);
    public Task Delete(int id, CancellationToken ct);
}
