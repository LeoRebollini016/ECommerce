using MediatR;
using Shared.Dtos.Clients;

namespace APPLICATION.Features.Clients.Commands.CreateClient;

public record CreateClientCommand(CreateClientDto createClientDto): IRequest<ClientDto>;
