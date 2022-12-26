using MarcakiService.Domain.Commands;
using MarcakiService.Domain.Entities.Aggregates;
using MarcakiService.Domain.Events.Provider;
using MarcakiService.Domain.Repository;
using MediatR;

namespace MarcakiService.Cross.CommandHandlers;

public class CreateProviderCommandHandler : IRequestHandler<CreateProvider, Unit>
{
    private IAggregateRepository _repository;
    private readonly IMediator _mediator;

    public CreateProviderCommandHandler(IAggregateRepository repository, IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }
    
    public async Task<Unit> Handle(CreateProvider request, CancellationToken cancellationToken)
    {
        var provider = new Provider(request);
        var @event = new ProviderCreated(request);

        provider.AddEvent(@event);
        await _repository.Add(provider);

        await _mediator.Publish(@event, cancellationToken);
        return await Unit.Task;
    }
}