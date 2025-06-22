using AutoMapper;
using DOMAIN.Interfaces.Services;
using MediatR;
using Shared.Dtos.Clients;

namespace APPLICATION.Features.Clients.Queries.GetClientById;

public class GetClientByIdHandler(IClientService _clientService, IMapper _mapper): IRequestHandler<GetClientByIdQuery, ClientDto>
{
    public async Task<ClientDto> Handle(GetClientByIdQuery request, CancellationToken ct)
        => _mapper.Map<ClientDto>(
                 await _clientService.GetClientById(request.id, ct));
}
