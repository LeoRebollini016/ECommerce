using APPLICATION.Features.Orders.Command.Add;
using APPLICATION.Features.Orders.Command.Delete;
using APPLICATION.Features.Orders.Command.Update;
using APPLICATION.Features.Orders.Queries;
using APPLICATION.Features.Orders.Queries.GetAllSummary;
using APPLICATION.Features.Orders.Queries.GetOrders;
using APPLICATION.Features.Orders.Queries.GetWithDetailById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Order;

namespace API.Endpoints;

public static class OrderEndpoint
{
    public static void MapOrderEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/Orders", async (
            [FromServices] IMediator mediator,
            CancellationToken ct
            ) =>
        {
            var request = new GetOrdersQuery();
            var result = await mediator.Send(request, ct);
            return Results.Ok(result);
        });
        app.MapGet("/OrdersWithSummary", async (
            [FromServices] IMediator mediator,
            CancellationToken ct
            ) =>
        {
            var request = new GetAllSummaryQuery();
            var result = await mediator.Send(request, ct);
            return Results.Ok(result);
        });
        app.MapGet("/OrderById/{id}", async (
            [FromRoute] int id,
            [FromServices] IMediator mediator,
            CancellationToken ct
            ) =>
        {
            var request = new GetOrderByIdQuery(id);
            var result = await mediator.Send(request, ct);
            return Results.Ok(result);
        });
        app.MapPost("/CreateOrder", async (
            [FromBody] CreateOrderDto createOrderDto,
            [FromServices] IMediator mediator,
            CancellationToken ct
            ) =>
        {
            var request = new AddOrderQuery(createOrderDto);
            var result = await mediator.Send(request, ct);
            return Results.Ok(result);
        });
        app.MapPut("/UpdateOrder/{id}", async (
            [FromRoute] int id,
            [FromBody] CreateOrderDto createOrderDto,
            [FromServices] IMediator mediator,
            CancellationToken ct
            ) =>
        {
            var request = new UpdateOrderQuery(createOrderDto, id);
            await mediator.Send(request, ct);
            return Results.NoContent();
        });
        app.MapDelete("DeleteOrder/{id}", async (
            [FromRoute] int id,
            [FromServices] IMediator mediator,
            CancellationToken ct
            ) =>
        {
            var request = new DeleteOrderQuery(id);
            await mediator.Send(request, ct);
            return Results.NoContent();
        });
    }
}
