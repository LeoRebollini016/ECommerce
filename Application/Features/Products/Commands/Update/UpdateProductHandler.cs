using AutoMapper;
using DOMAIN.Interfaces.Services;
using MediatR;

namespace APPLICATION.Features.Products.Commands.Update;

public class UpdateProductHandler(IProductService _productService, IMapper _mapper) : IRequestHandler<UpdateProductCommand, Unit>
{
    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var existingProduct =  await _productService.FindByIdAsync(request.id, cancellationToken);
        _mapper.Map(request.createProductDto, existingProduct);
        await _productService.Update(existingProduct!, cancellationToken);
        return Unit.Value;
    }
}
