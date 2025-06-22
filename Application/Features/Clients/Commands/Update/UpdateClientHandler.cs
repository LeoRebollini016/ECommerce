using AutoMapper;
using DOMAIN.Interfaces.Services;
using MediatR;

namespace APPLICATION.Features.Clients.Commands.UpdateClient;

public class UpdateClientHandler(IClientService _clientService, IMapper _mapper) : IRequestHandler<UpdateClientCommand, Unit>
{
    public async Task<Unit> Handle(UpdateClientCommand request, CancellationToken ct)
    {
        var existingClient = await _clientService.GetClientById(request.id, ct);
        var client = _mapper.Map(request.createClientDto, existingClient)!;
        await _clientService.Update(client, ct);
        return Unit.Value;
    }
}
