using APPLICATION.Dtos.Products;
using MediatR;

namespace APPLICATION.Features.Products.Queries;

public record GetProductsQuery(): IRequest<IEnumerable<ProductDto>>;

