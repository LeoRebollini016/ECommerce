using MediatR;

namespace APPLICATION.Features.Products.Commands.Delete;

public record DeleteProductCommand(int id) : IRequest<Unit>;
