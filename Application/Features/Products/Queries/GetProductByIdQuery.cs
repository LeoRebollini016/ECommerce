using APPLICATION.Dtos.Products;
using MediatR;

namespace APPLICATION.Features.Products.Queries;

public record GetProductByIdQuery(int id): IRequest<ProductDto?>;
