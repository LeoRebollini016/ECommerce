using APPLICATION.Dtos.Products;
using APPLICATION.Features.Products.Commands;
using APPLICATION.Features.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/Products", async (
            [FromServices] IMediator mediator,
            CancellationToken ct
            ) =>
            {
                var request = new GetProductsQuery();
                var results = await mediator.Send(request, ct);
                return Results.Ok(results);
            });
        app.MapGet("/Product/{id}", async (
            [FromRoute] int id,
            [FromServices] IMediator mediator,
            CancellationToken ct
            ) =>
        {
            var request = new GetProductByIdQuery(id);
            var results = await mediator.Send(request, ct);
            return Results.Ok(results);
        });
        app.MapPost("CreateProduct", async (
            [FromBody] ProductDto productDto,
            [FromServices] IMediator mediator,
            CancellationToken ct
            ) =>
        {
            var request = new CreateProductCommand(productDto);
            var results = await mediator.Send(request, ct);
            return Results.Ok(results);
        });
        app.MapPut("UpdateProduct/{id}", async (
            [FromRoute] int id,
            [FromBody] ProductDto productDto,
            [FromServices] IMediator mediator,
            CancellationToken ct) => 
        { 
            var request = new UpdateProductCommand(id, productDto);
            await mediator.Send(request, ct);
            return Results.NoContent();
        });
        app.MapDelete("DeleteProduct/{id}", async (
            [FromRoute] int id,
            [FromServices] IMediator mediator,
            CancellationToken ct
            ) =>
        {
            var request = new DeleteProductCommand(id);
            await mediator.Send(request, ct);
            return Results.NoContent();
        });
    }
}
