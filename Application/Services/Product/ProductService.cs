using DOMAIN.Interfaces.Repositories;
using DOMAIN.Interfaces.Services;

namespace APPLICATION.Services.Product;

public class ProductService(ICommandGenerics _command, IProductRepository _productRepository) : IProductService
{
    public async Task AddAsync(DOMAIN.Entities.Product T, CancellationToken ct)
    {
        await _command.AddAsync(T, ct);
        await _command.SaveChangeAsync(ct);
    }
    public async Task Delete(int id, CancellationToken ct)
    {
        await _productRepository.Delete(id, ct);
        await _command.SaveChangeAsync(ct);
    }
    public async Task<DOMAIN.Entities.Product?> FindByIdAsync(int id, CancellationToken ct)
     => await _productRepository.FindByIdAsync(id, ct);

    public async Task<IEnumerable<DOMAIN.Entities.Product>> GetProducts(CancellationToken ct)
     => await _command.GetAllAsync<DOMAIN.Entities.Product>(ct);

    public async Task Update(DOMAIN.Entities.Product newProduct, CancellationToken ct)
    {
        _command.Update(newProduct);
        await _command.SaveChangeAsync(ct);
    }
}
