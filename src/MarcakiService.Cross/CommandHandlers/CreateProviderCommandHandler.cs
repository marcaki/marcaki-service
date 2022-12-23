using MarcakiService.Domain.Commands;
using MarcakiService.Domain.Entities.Aggregates;
using MarcakiService.Domain.Events;
using MarcakiService.Domain.Repository;
using MediatR;

namespace MarcakiService.Cross.CommandHandlers;

public class CreateProviderCommandHandler : IRequestHandler<CreateProvider, Unit>
{
    private IAggregateRepository _repository;

    public CreateProviderCommandHandler(IAggregateRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Unit> Handle(CreateProvider request, CancellationToken cancellationToken)
    {
        var provider = new Provider(request);
        var @event = new ProviderCreated(request);

        provider.AddEvent(@event);
        await _repository.Add(provider);
        return await Unit.Task;
    }
}