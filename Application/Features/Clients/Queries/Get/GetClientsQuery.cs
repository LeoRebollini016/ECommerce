using MediatR;
using Shared.Dtos.Clients;

namespace APPLICATION.Features.Clients.Queries.GetClients;

public record GetClientsQuery(): IRequest<List<ClientDto>>;
