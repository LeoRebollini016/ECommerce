using APPLICATION.Features.Products.Commands.Update;
using DOMAIN.Interfaces.Repositories;
using FluentValidation;

namespace APPLICATION.Validators.T;

public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductValidator(IProductRepository repository)
    {
        RuleFor(x => x.id)
            .MustAsync(async (id, cancellation) =>
            {
                var exist = await repository.ExistsAsync(id, cancellation);
                return exist;
            })
            .WithMessage("El producto no existe.");

        RuleFor(x => x.createProductDto.Name)
            .NotEmpty()
            .MaximumLength(100).WithMessage("El nombre no debe superar los 100 caracteres.");
        RuleFor(x => x.createProductDto.Description)
            .MaximumLength(200).WithMessage("La descripción no debe superar los 200 caracteres");
        RuleFor(x => x.createProductDto.Price)
            .GreaterThan(0).WithMessage("El precio debe ser mayor a cero.");
        RuleFor(x => x.createProductDto.Stock)
            .GreaterThanOrEqualTo(0).WithMessage("El stock tiene que ser mayor o igual a 0.");
    }
}