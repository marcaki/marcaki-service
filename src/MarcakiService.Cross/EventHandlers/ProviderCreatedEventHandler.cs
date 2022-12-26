using MarcakiService.Domain.Entities.Projections;
using MarcakiService.Domain.Events.Provider;
using MarcakiService.Domain.Repository;
using MediatR;

namespace MarcakiService.Cross.EventHandlers;

public class ProviderCreatedEventHandler :  INotificationHandler<ProviderCreated>
{
    private readonly IProviderRepository _repository;

    public ProviderCreatedEventHandler(IProviderRepository repository)
    {
        _repository = repository;
    }
    
    public async Task Handle(ProviderCreated notification, CancellationToken cancellationToken)
    {
        var provider = new ProviderProjection(notification);
        await _repository.Add(provider);
    }
}