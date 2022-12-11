using MarcakiService.Domain.Entities.ValueObjects;

namespace MarcakiService.Application.Contracts;

public class AvailabilityRequest
{
    public string Monday { get; set; }
    public string Tuesday { get; set; }
    public string Wednesday { get; set; }
    public string Thursday { get; set; }
    public string Friday { get; set; }
    public string Saturday { get; set; }
    public string Sunday { get; set; }

    public Availability ToDomain()
    {
        return new Availability(Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday);
    }
}