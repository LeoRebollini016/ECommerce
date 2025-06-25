using DOMAIN.Interfaces.Services;
using MediatR;

namespace APPLICATION.Features.Orders.Command.Delete;

public class DeleteOrderHandler(IOrderService _orderService) : IRequestHandler<DeleteOrderQuery, Unit>
{
    public async Task<Unit> Handle(DeleteOrderQuery request, CancellationToken ct)
    {
        await _orderService.DeleteAsync(request.id, ct);
        return Unit.Value;
    }
}

