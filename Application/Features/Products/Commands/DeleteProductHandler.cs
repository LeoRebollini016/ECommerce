using AutoMapper;
using DOMAIN.Interfaces;
using MediatR;

namespace APPLICATION.Features.Products.Commands;

public class DeleteProductHandler(IProductRepository repository, IMapper mapper): IRequestHandler<DeleteProductCommand, Unit>
{
    private readonly IProductRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        await _repository.Delete(request.id, cancellationToken);
        return Unit.Value;
    }
}
