using AutoMapper;
using DOMAIN.Interfaces.Services;
using MediatR;
using Shared.Dtos.Order;

namespace APPLICATION.Features.Orders.Queries.GetOrders;

public class GetOrdersHandler(IOrderService _orderService, IMapper _mapper): IRequestHandler<GetOrdersQuery, List<OrderWithoutDetailsDto>>
{
    public async Task<List<OrderWithoutDetailsDto>> Handle(GetOrdersQuery request, CancellationToken ct)
        => _mapper.Map<List<OrderWithoutDetailsDto>>(await _orderService.GetAllAsync(ct));
}
