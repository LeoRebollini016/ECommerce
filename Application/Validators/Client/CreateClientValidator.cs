using APPLICATION.Features.Clients.Commands.CreateClient;
using DOMAIN.Interfaces.Repositories;
using FluentValidation;

namespace APPLICATION.Validators.Client;

public class CreateClientValidator: AbstractValidator<CreateClientCommand>
{
    public CreateClientValidator(IClientRepository clientRepository)
    {
        RuleFor(x => x.createClientDto.Email)
            .NotEmpty().WithMessage("El email es obligatorio")
            .EmailAddress().WithMessage("Debe ser un tipo de email válido.")
            .MustAsync(async (email, cancellation) =>
            {
                var alreadyExists = await clientRepository.ExistsByEmailAsync(email, cancellation);
                return !alreadyExists;
            }).WithMessage("El email ya pertenece a nuestros clientes.");

        RuleFor(x => x.createClientDto.Name)
            .NotEmpty()
            .WithMessage("El nombre es obligatorio.");
        RuleFor(x => x.createClientDto.Direccion)
            .NotEmpty()
            .WithMessage("La dirección es obligatoria");
    }
}