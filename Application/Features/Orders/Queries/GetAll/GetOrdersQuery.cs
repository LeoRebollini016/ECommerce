using MediatR;
using Shared.Dtos.Order;

namespace APPLICATION.Features.Orders.Queries.GetOrders;

public record GetOrdersQuery: IRequest<List<OrderWithoutDetailsDto>>;

