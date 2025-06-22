using AutoMapper;
using DOMAIN.Interfaces.Repositories;
using DOMAIN.Interfaces.Services;
using MediatR;

namespace APPLICATION.Features.Products.Commands.Delete;

public class DeleteProductHandler(IProductService _productService): IRequestHandler<DeleteProductCommand, Unit>
{
    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        await _productService.Delete(request.id, cancellationToken);
        return Unit.Value;
    }
}
