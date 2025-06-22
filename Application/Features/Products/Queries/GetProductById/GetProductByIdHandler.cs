using APPLICATION.Dtos.Products;
using AutoMapper;
using Azure.Core;
using DOMAIN.Interfaces.Repositories;
using DOMAIN.Interfaces.Services;
using MediatR;
using System.Threading;

namespace APPLICATION.Features.Products.Queries.GetProductById;

public class GetProductByIdHandler(IProductService _productService, IMapper _mapper) :IRequestHandler<GetProductByIdQuery, ProductDto?>
{
    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        =>  _mapper.Map<ProductDto>(await _productService.FindByIdAsync(request.id, cancellationToken));
}