using MediatR;
using Shared.Dtos.Order;
namespace APPLICATION.Features.Orders.Queries.GetWithDetailById;

public record GetOrderByIdQuery(int id): IRequest<OrderDto>;


