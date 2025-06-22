using APPLICATION.Dtos.Products;
using MediatR;

namespace APPLICATION.Features.Products.Queries.GetProductById;

public record GetProductByIdQuery(int id): IRequest<ProductDto?>;
