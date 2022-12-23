using MediatR;

namespace MarcakiService.Domain.Commands;

public class Command : ICommand, IRequest<Unit>
{
    public string AggregateId { get; set; }
    
    protected Command(string aggregateId)
    {
        AggregateId = aggregateId;
    }
}