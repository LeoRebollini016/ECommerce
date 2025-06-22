using APPLICATION.Dtos.Products;
using APPLICATION.Features.Products.Commands.Create;
using APPLICATION.Features.Products.Commands.Delete;
using APPLICATION.Features.Products.Commands.Update;
using APPLICATION.Features.Products.Queries.GetProductById;
using APPLICATION.Features.Products.Queries.GetProducts;
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
            [FromBody] CreateProductDto createProductDto,
            [FromServices] IMediator mediator,
            CancellationToken ct
            ) =>
        {
            var request = new CreateProductCommand(createProductDto);
            var results = await mediator.Send(request, ct);
            return Results.Ok(results);
        });
        app.MapPut("UpdateProduct/{id}", async (
            [FromRoute] int id,
            [FromBody] CreateProductDto createProductDto,
            [FromServices] IMediator mediator,
            CancellationToken ct) => 
        { 
            var request = new UpdateProductCommand(id, createProductDto);
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
