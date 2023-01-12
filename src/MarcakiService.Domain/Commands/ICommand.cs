namespace MarcakiService.Domain.Commands;

public interface ICommand
{
    public string AggregateId { get; set; }
}