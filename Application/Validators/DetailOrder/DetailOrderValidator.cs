using DOMAIN.Interfaces.Repositories;
using FluentValidation;
using Shared.Dtos.Order;

namespace APPLICATION.Validators.DetailOrder;

public class DetailOrderValidator : AbstractValidator<DetailOrderDto>
{
    public DetailOrderValidator(IProductRepository _productRepository)
    {
        RuleFor(x => x.ProductId)
            .NotEmpty().WithMessage("Se debe especificar un producto válido")
            .MustAsync(async (id, ct) =>
            {
                var existProduct = await _productRepository.ExistsAsync(id, ct);
                return existProduct;
            });
        RuleFor(x => x.Quantity)
            .NotEmpty().WithMessage("La cantidad es obligatoria.")
            .GreaterThan(0).WithMessage("La cantidad debe ser mayor a 0.");
        RuleFor(x => x.SubTotal)
            .NotEmpty().WithMessage("Es obligatorio el subtotal")
            .GreaterThan(0).WithMessage("El subtotal debe ser mayor a 0.");
    }
}
