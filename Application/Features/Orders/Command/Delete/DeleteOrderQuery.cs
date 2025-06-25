using MediatR;

namespace APPLICATION.Features.Orders.Command.Delete;

public record DeleteOrderQuery(int id): IRequest<Unit>;

