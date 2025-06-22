using APPLICATION.Features.Clients.Commands.Delete;
using DOMAIN.Interfaces.Repositories;
using FluentValidation;

namespace APPLICATION.Validators.Client;

public class DeleteClientValidator: AbstractValidator<DeleteClientCommand>
{
    public DeleteClientValidator(IClientRepository _clientRepository)
    {
        RuleFor(x => x.id)
            .NotEmpty().WithMessage("La Id es obligatoria.")
            .MustAsync(async (id, ct) => {
                var existClient = await _clientRepository.ExistsByIdAsync(id, ct);
                return existClient;
            }).WithMessage("El client no existe.");
    }
}
