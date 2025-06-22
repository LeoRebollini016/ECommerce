using AutoMapper;
using DOMAIN.Interfaces.Services;
using MediatR;
using Shared.Dtos.Clients;

namespace APPLICATION.Features.Clients.Queries.GetClients;

public class GetClientsHandler(IClientService _clientService, IMapper _mapper) : IRequestHandler<GetClientsQuery, List<ClientDto>>
{
    public async Task<List<ClientDto>> Handle(GetClientsQuery request, CancellationToken ct)
        => _mapper.Map<List<ClientDto>>(
                await _clientService.GetAllAsync(ct));
}
