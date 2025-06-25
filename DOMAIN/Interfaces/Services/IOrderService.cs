using DOMAIN.Entities;
using Shared.Dtos.Order;

namespace DOMAIN.Interfaces.Services;

public interface IOrderService
{
    public Task<IEnumerable<Order>> GetAllAsync(CancellationToken ct);
    public Task<IEnumerable<Order>> GetAllSummaryAsync(CancellationToken ct);
    public Task<Order?> GetOrderWithDetailsById(int id);
    public Task AddAsync(Order entity, CancellationToken ct);
    public Task Update(Order entity, CancellationToken ct);
    public Task DeleteAsync(int id, CancellationToken ct);
}