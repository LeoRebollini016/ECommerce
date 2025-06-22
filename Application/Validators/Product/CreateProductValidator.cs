using APPLICATION.Features.Products.Commands.Create;
using FluentValidation;

namespace APPLICATION.Validators.T;

public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
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
