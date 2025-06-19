using APPLICATION.Dtos.Products;
using AutoMapper;
using DOMAIN.Interfaces;
using MediatR;

namespace APPLICATION.Features.Products.Queries;

public class GetProductByIdHandler(IProductRepository productRepository, IMapper mapper) :IRequestHandler<GetProductByIdQuery, ProductDto?>
{
    private readonly IProductRepository _repository = productRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _repository.FindByIdAsync(request.id, cancellationToken);
        return mapper.Map<ProductDto>(product);
    }
}
