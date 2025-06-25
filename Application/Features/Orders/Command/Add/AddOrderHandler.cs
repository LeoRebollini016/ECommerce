using AutoMapper;
using DOMAIN.Entities;
using DOMAIN.Interfaces.Services;
using MediatR;
using Shared.Dtos.Order;

namespace APPLICATION.Features.Orders.Command.Add;

public class AddOrderHandler(IOrderService _orderService, IMapper _mapper) : IRequestHandler<AddOrderQuery, OrderDto>
{
    public async Task<OrderDto> Handle(AddOrderQuery request, CancellationToken ct)
    {
        var order = _mapper.Map<Order>(request.createOrderDto);
        await _orderService.AddAsync(order, ct);
        return _mapper.Map<OrderDto>(order);
    }
}