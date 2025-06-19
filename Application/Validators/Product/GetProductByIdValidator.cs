using APPLICATION.Features.Products.Queries;
using DOMAIN.Interfaces;
using FluentValidation;

namespace APPLICATION.Validators.Product;

public class GetProductByIdValidator : AbstractValidator<GetProductByIdQuery>
{
    public GetProductByIdValidator(IProductRepository _repository)
    {
        RuleFor(x => x.id)
            .NotEmpty()
            .GreaterThanOrEqualTo(0)
            .WithMessage("No seleccionaste un ID valido.");
        RuleFor(x => x.id)
            .MustAsync(async (id, cancellationToken) =>
            {
                var exists = await _repository.ExistsAsync(id, cancellationToken);
                return exists;
            })
            .WithMessage("No existe producto con ese ID.");
    }
}
