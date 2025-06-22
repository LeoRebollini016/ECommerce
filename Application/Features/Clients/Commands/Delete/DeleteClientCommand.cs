using MediatR;

namespace APPLICATION.Features.Clients.Commands.Delete;

public record DeleteClientCommand(int id): IRequest<Unit>;
