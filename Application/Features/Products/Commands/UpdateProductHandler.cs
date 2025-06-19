using AutoMapper;
using DOMAIN.Entities;
using DOMAIN.Interfaces;
using MediatR;

namespace APPLICATION.Features.Products.Commands;

public class UpdateProductHandler(IProductRepository repository, ICommandGenerics _command, IMapper mapper) : IRequestHandler<UpdateProductCommand, Unit>
{
    private readonly IProductRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var existingProduct =  await _repository.FindByIdAsync(request.productDto.Id, cancellationToken);

        _mapper.Map(request.productDto, existingProduct);
        _command.Update<Product>(existingProduct!);
        await _command.SaveChangeAsync(cancellationToken);

        return Unit.Value;
    }
}
