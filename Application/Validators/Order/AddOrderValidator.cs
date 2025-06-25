using APPLICATION.Features.Orders.Command.Add;
using APPLICATION.Validators.DetailOrder;
using DOMAIN.Interfaces.Repositories;
using FluentValidation;
using Shared.Dtos.Order;

namespace APPLICATION.Validators.Order;

public class AddOrderValidator: AbstractValidator<AddOrderQuery>
{
    public AddOrderValidator(IClientRepository _clientRepository, IValidator<DetailOrderDto> detailValidator)
    {
        RuleFor(x => x.createOrderDto.State)
            .NotEmpty().WithMessage("El campo estado es obligatorio");
        RuleFor(x => x.createOrderDto.Date)
            .NotEmpty().WithMessage("La fecha es obligatoria.");
        RuleFor(x => x.createOrderDto.ClientId)
            .NotEmpty().WithMessage("La orden debe estar asociada a un cliente")
            .MustAsync(async (id, ct) =>
            {
                var existClient = await _clientRepository.ExistsByIdAsync(id, ct);
                return existClient;
            }).WithMessage("El cliente asociado no existe.");
        RuleFor(x => x.createOrderDto.Details)
            .NotEmpty().WithMessage("El detalle de la orden es obligatorio.");
        RuleForEach(x => x.createOrderDto.Details)
            .SetValidator(detailValidator);
    }
}
