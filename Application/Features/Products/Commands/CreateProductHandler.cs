using APPLICATION.Dtos.Products;
using AutoMapper;
using DOMAIN.Entities;
using DOMAIN.Interfaces;
using MediatR;

namespace APPLICATION.Features.Products.Commands;

public class CreateProductHandler(IProductRepository repository, IMapper mapper) : IRequestHandler<CreateProductCommand, ProductDto>
{
    private readonly IProductRepository _repository = repository;
    private readonly IMapper _mapper = mapper;
    public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request.productDto);
        await _repository.Create(product);
        var productResponseDto = _mapper.Map<ProductDto>(product);
        return productResponseDto;
    }
}
