using APPLICATION.Features.Orders.Command.Delete;
using DOMAIN.Interfaces.Repositories;
using FluentValidation;

namespace APPLICATION.Validators.Order;

public class DeleteOrderValidator : AbstractValidator<DeleteOrderQuery>
{
    public DeleteOrderValidator(IOrderRepository _orderRepository)
    {
        RuleFor(x => x.id)
            .NotEmpty().WithMessage("El ID es obligatorio")
            .MustAsync(async (id, ct) =>
            {
                var existOrder = await _orderRepository.ExistOrderById(id, ct);
                return existOrder;
            }).WithMessage("No existe orden asociada a ese ID.");
    }
}
