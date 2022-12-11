using MediatR;

namespace MarcakiService.Domain.Commands;

public class Command : ICommand, IRequest<Unit>
{
    public string Id { get; set; }
}