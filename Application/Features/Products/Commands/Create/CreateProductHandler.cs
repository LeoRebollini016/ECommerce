using APPLICATION.Dtos.Products;
using AutoMapper;
using DOMAIN.Entities;
using DOMAIN.Interfaces.Repositories;
using DOMAIN.Interfaces.Services;
using MediatR;

namespace APPLICATION.Features.Products.Commands.Create;

public class CreateProductHandler(IProductService _productService, IMapper _mapper) : IRequestHandler<CreateProductCommand, ProductDto>
{
    public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var Product = _mapper.Map<Product>(request.createProductDto);
        await _productService.AddAsync(Product, cancellationToken);
        var productResponseDto = _mapper.Map<ProductDto>(Product);
        return productResponseDto;
    }
}
