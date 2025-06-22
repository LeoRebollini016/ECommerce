using APPLICATION.Dtos.Products;
using MediatR;

namespace APPLICATION.Features.Products.Commands.Update;

public record UpdateProductCommand(int id, CreateProductDto createProductDto): IRequest<Unit>;