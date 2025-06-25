using MediatR;
using Shared.Dtos.Order;
namespace APPLICATION.Features.Orders.Command.Add;

public record AddOrderQuery(CreateOrderDto createOrderDto): IRequest<OrderDto>;