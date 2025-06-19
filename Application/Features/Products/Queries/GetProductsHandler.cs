using APPLICATION.Dtos.Products;
using AutoMapper;
using DOMAIN.Interfaces;
using MediatR;

namespace APPLICATION.Features.Products.Queries;

public class GetProductsHandler(IProductRepository repository, IMapper mapper) : IRequestHandler<GetProductsQuery, IEnumerable<ProductDto>>
{
    private readonly IProductRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<ProductDto?>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _repository.GetProducts(cancellationToken);
        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }
}