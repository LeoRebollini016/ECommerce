using APPLICATION.Features.Clients.Commands.CreateClient;
using APPLICATION.Features.Clients.Commands.Delete;
using APPLICATION.Features.Clients.Commands.UpdateClient;
using APPLICATION.Features.Clients.Queries.GetClientById;
using APPLICATION.Features.Clients.Queries.GetClients;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos.Clients;

namespace API.Endpoints;

public static class ClientEndpoints
{
    public static void MapClientEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/Clients", async (
            [FromServices] IMediator mediator,
            CancellationToken ct
            ) =>
        {
            var request = new GetClientsQuery();
            var results = await mediator.Send(request, ct);
            return Results.Ok(results);
        });
        app.MapGet("/Client/{id}", async (
            [FromRoute] int id,
            [FromServices] IMediator mediator,
            CancellationToken ct
            ) => 
        { 
            var request = new GetClientByIdQuery(id);
            var result = await mediator.Send(request, ct);
            return Results.Ok(result);
        });
        app.MapPost("/CreateClient", async (
            [FromBody] CreateClientDto createClientDto,
            [FromServices] IMediator mediator,
            CancellationToken ct
            ) =>
        {
            var request = new CreateClientCommand(createClientDto);
            var result = await mediator.Send(request, ct);
            return Results.Ok(result);
        });
        app.MapPut("/UpdateClient/{id}", async (
            [FromRoute] int id,
            [FromBody] CreateClientDto createClientDto,
            [FromServices] IMediator mediator,
            CancellationToken ct
            ) => 
        {
            var request = new UpdateClientCommand(id, createClientDto);
            await mediator.Send(request, ct);
            return Results.NoContent();
        });
        app.MapDelete("/DeleteClient/{id}", async (
            [FromRoute] int id,
            [FromServices] IMediator mediator,
            CancellationToken ct
            ) =>
        {
            var request = new DeleteClientCommand(id);
            await mediator.Send(request, ct);
            return Results.NoContent();
        });
    }
}
