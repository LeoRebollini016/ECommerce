using APPLICATION.Features.Clients.Queries.GetClientById;
using DOMAIN.Interfaces.Repositories;
using FluentValidation;

namespace APPLICATION.Validators.Client;

public class GetClientByIdValidator: AbstractValidator<GetClientByIdQuery>
{
    public GetClientByIdValidator(IClientRepository _clientRepository)
    {
        RuleFor(x => x.id)
            .NotEmpty().WithMessage("El ID es obligatorio.")
            .GreaterThanOrEqualTo(0).WithMessage("El ID tiene que ser un número positivo.")
            .MustAsync(async (id, ct) =>
            {
                var existClient = await _clientRepository.ExistsByIdAsync(id, ct);
                return existClient;
            }).WithMessage("El cliente no existe.");
    }
}
