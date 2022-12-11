using MarcakiService.Domain.Commands;
using MarcakiService.Domain.Entities.Aggregates;
using MarcakiService.Domain.Repository;
using MediatR;

namespace MarcakiService.Cross.CommandHandlers;

public class CreateProviderCommandHandler : IRequestHandler<CreateProvider, Unit>
{
    private IProviderRepository _repository;

    public CreateProviderCommandHandler(IProviderRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Unit> Handle(CreateProvider request, CancellationToken cancellationToken)
    {
        var provider = new Provider(request);
        await _repository.Add(provider);
        return await Unit.Task;
    }
}