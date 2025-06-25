using AutoMapper;
using DOMAIN.Interfaces.Services;
using MediatR;
using Shared.Dtos.Order;

namespace APPLICATION.Features.Orders.Queries.GetWithDetailById;

public class GetOrderByIdHandler(IOrderService _orderService, IMapper _mapper) : IRequestHandler<GetOrderByIdQuery, OrderDto>
{
    public async Task<OrderDto> Handle(GetOrderByIdQuery request, CancellationToken ct)
        => _mapper.Map<OrderDto>(await _orderService.GetOrderWithDetailsById(request.id));
}
