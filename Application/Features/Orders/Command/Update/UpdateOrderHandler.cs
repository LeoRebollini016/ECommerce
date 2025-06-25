using AutoMapper;
using DOMAIN.Interfaces.Services;
using MediatR;

namespace APPLICATION.Features.Orders.Command.Update;

public class UpdateOrderHandler(IOrderService _orderService, IMapper _mapper) : IRequestHandler<UpdateOrderQuery, Unit>
{
    public async Task<Unit> Handle(UpdateOrderQuery request, CancellationToken ct)
    {
        var existProduct = await _orderService.GetOrderWithDetailsById(request.id);
        _mapper.Map(request.createOrderDto, existProduct);
        await _orderService.Update(existProduct!, ct);
        return Unit.Value;
    }
}