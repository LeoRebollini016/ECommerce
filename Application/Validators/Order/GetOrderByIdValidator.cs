using APPLICATION.Features.Orders.Queries.GetWithDetailById;
using DOMAIN.Interfaces.Repositories;
using FluentValidation;

namespace APPLICATION.Validators.Order;

public class GetOrderByIdValidator: AbstractValidator<GetOrderByIdQuery>
{
    public GetOrderByIdValidator(IOrderRepository _orderRepository)
    {
        RuleFor(x => x.id)
            .NotEmpty().WithMessage("El campo Id es obligatorio")
            .MustAsync(async (id, ct) =>
            {
                var existOrder = await _orderRepository.ExistOrderById(id, ct);
                return existOrder;
            }).WithMessage("El Id no esta asociado a ninguna orden.");
    }
}
