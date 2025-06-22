using AutoMapper;
using DOMAIN.Entities;
using DOMAIN.Interfaces.Services;
using MediatR;
using Shared.Dtos.Clients;

namespace APPLICATION.Features.Clients.Commands.CreateClient;

public class CreateClientHandler(IClientService _clientService, IMapper _mapper) : IRequestHandler<CreateClientCommand, ClientDto>
{
    public async Task<ClientDto> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        var client = _mapper.Map<Client>(request.createClientDto);
        await _clientService.AddAsync(client, cancellationToken);
        var clientDto = _mapper.Map<ClientDto>(client);
        return clientDto;
    }
}
