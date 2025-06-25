using APPLICATION.Dtos.Products;
using MediatR;
using Shared.Dtos.Order;

namespace APPLICATION.Features.Orders.Command.Update;

public record UpdateOrderQuery(CreateOrderDto createOrderDto, int id): IRequest<Unit>;
