using AutoMapper;
using DOMAIN.Interfaces.Services;
using MediatR;
using Shared.Dtos.Order;

namespace APPLICATION.Features.Orders.Queries.GetAllSummary;

public class GetAllSummaryHandler(IOrderService _orderService, IMapper _mapper) : IRequestHandler<GetAllSummaryQuery, List<OrderDto>>
{
    public async Task<List<OrderDto>> Handle(GetAllSummaryQuery request, CancellationToken ct)
        => _mapper.Map<List<OrderDto>>(await _orderService.GetAllSummaryAsync(ct));
}
