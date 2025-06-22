using DOMAIN.Interfaces.Services;
using MediatR;

namespace APPLICATION.Features.Clients.Commands.Delete;

public class DeleteClientHandler(IClientService _clientService) : IRequestHandler<DeleteClientCommand, Unit>
{
    public async Task<Unit> Handle(DeleteClientCommand request, CancellationToken ct)
    {
        await _clientService.Delete(request.id, ct);
        return Unit.Value;
    } 
}
