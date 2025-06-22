using MediatR;
using Shared.Dtos.Clients;

namespace APPLICATION.Features.Clients.Queries.GetClientById;

public record GetClientByIdQuery(int id): IRequest<ClientDto>;

