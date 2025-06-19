using APPLICATION.Features.Products.Commands;
using DOMAIN.Interfaces;
using FluentValidation;

namespace APPLICATION.Validators.Product;

public class DeleteProductValidator: AbstractValidator<DeleteProductCommand>
{
    public DeleteProductValidator(IProductRepository repository)
    {
        RuleFor(x => x.id)
            .NotEmpty().WithMessage("El ID del producto es obligatorio.")
            .GreaterThanOrEqualTo(0).WithMessage("No existen productos con IDs negativos.")
            .MustAsync(async (id, CancellationToken) =>
            {
                var exists = await repository.ExistsAsync(id, CancellationToken);
                return exists;
            })
            .WithMessage("El ID del producto no se ha encontrado.");
    }
}
