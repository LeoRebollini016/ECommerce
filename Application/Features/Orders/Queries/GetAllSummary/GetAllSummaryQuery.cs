using MediatR;
using Shared.Dtos.Order;

namespace APPLICATION.Features.Orders.Queries.GetAllSummary;

public record GetAllSummaryQuery(): IRequest<List<OrderDto>>;
