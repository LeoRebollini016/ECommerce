using APPLICATION.Features.Clients.Commands.UpdateClient;
using DOMAIN.Interfaces.Repositories;
using FluentValidation;

namespace APPLICATION.Validators.Client;

public class UpdateClientValidator: AbstractValidator<UpdateClientCommand>
{
    public UpdateClientValidator(IClientRepository clientRepository)
    {
        
    }
}
