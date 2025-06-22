using MediatR;
using Shared.Dtos.Clients;

namespace APPLICATION.Features.Clients.Commands.UpdateClient;

public record UpdateClientCommand(int id, CreateClientDto createClientDto):IRequest<Unit>;