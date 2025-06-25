
using DOMAIN.Interfaces.Repositories;
using DOMAIN.Interfaces.Services;
using Shared.Dtos.Order;
using System.Threading.Tasks;

namespace APPLICATION.Services.Order;

public class OrderService(ICommandGenerics _command, IOrderRepository _orderRepository) : IOrderService
{
    public async Task AddAsync(DOMAIN.Entities.Order entity, CancellationToken ct)
    {
        await _command.AddAsync(entity, ct);
        await _command.SaveChangeAsync(ct);
    }

    public async Task DeleteAsync(int id, CancellationToken ct)
    {
        await _orderRepository.DeleteAsync(id, ct);
        await _command.SaveChangeAsync(ct);
    }

    public async Task<IEnumerable<DOMAIN.Entities.Order>> GetAllAsync(CancellationToken ct)
        => await _command.GetAllAsync<DOMAIN.Entities.Order>(ct);

    public async Task<IEnumerable<DOMAIN.Entities.Order>> GetAllSummaryAsync(CancellationToken ct)
        => await _orderRepository.GetAllSummaryAsync(ct);

    public async Task<DOMAIN.Entities.Order?> GetOrderWithDetailsById(int id)
        => await _orderRepository.GetOrderWithDetailsById(id);

    public async Task Update(DOMAIN.Entities.Order entity, CancellationToken ct)
    {
        _command.Update(entity);
        await _command.SaveChangeAsync(ct);
    } 
}
