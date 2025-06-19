using APPLICATION.Dtos.Products;
using MediatR;

namespace APPLICATION.Features.Products.Commands;

public record CreateProductCommand(ProductDto productDto): IRequest<ProductDto>;