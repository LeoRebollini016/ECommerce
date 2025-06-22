using APPLICATION.Dtos.Products;
using MediatR;

namespace APPLICATION.Features.Products.Queries.GetProducts;

public record GetProductsQuery(): IRequest<List<ProductDto>>;

