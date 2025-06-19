using APPLICATION.Features.Products.Commands;
using FluentValidation;

namespace APPLICATION.Validators.Product;

public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.productDto.Name)
            .NotEmpty()
            .MaximumLength(100).WithMessage("El nombre no debe superar los 100 caracteres.");
        RuleFor(x => x.productDto.Description)
            .MaximumLength(200).WithMessage("La descripción no debe superar los 200 caracteres");
        RuleFor(x => x.productDto.Price)
            .GreaterThan(0).WithMessage("El precio debe ser mayor a cero.");
        RuleFor(x => x.productDto.Stock)
            .GreaterThanOrEqualTo(0).WithMessage("El stock tiene que ser mayor o igual a 0.");
    }
}
