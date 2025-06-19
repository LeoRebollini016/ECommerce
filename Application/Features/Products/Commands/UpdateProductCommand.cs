using APPLICATION.Dtos.Products;
using MediatR;

namespace APPLICATION.Features.Products.Commands;

public record UpdateProductCommand(int id, ProductDto productDto): IRequest<Unit>;