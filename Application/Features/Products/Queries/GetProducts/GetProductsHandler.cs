using APPLICATION.Dtos.Products;
using AutoMapper;
using DOMAIN.Interfaces.Services;
using MediatR;

namespace APPLICATION.Features.Products.Queries.GetProducts;

public class GetProductsHandler(IProductService _productService, IMapper _mapper) : IRequestHandler<GetProductsQuery, List<ProductDto>>
{
    public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        => _mapper.Map<List<ProductDto>>(await _productService.GetProducts(cancellationToken));
}