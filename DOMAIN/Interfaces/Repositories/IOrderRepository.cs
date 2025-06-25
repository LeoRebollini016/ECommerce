using DOMAIN.Entities;
using Shared.Dtos.Order;

namespace DOMAIN.Interfaces.Repositories;

public interface IOrderRepository
{
    public Task<IEnumerable<Order>> GetAllSummaryAsync(CancellationToken ct);
    public Task<Order?> GetOrderWithDetailsById(int id);
    public Task DeleteAsync(int id, CancellationToken ct);
    public Task<bool> ExistOrderById(int id, CancellationToken ct);
}
