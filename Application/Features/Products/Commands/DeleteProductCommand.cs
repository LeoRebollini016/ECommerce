using MediatR;

namespace APPLICATION.Features.Products.Commands;

public record DeleteProductCommand(int id) : IRequest<Unit>;
