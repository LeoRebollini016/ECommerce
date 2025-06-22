using APPLICATION.Dtos.Products;
using MediatR;

namespace APPLICATION.Features.Products.Commands.Create;

public record CreateProductCommand(CreateProductDto createProductDto): IRequest<ProductDto>;