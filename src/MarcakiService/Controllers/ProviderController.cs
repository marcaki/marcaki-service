using System.Linq;
using System.Threading.Tasks;
using MarcakiService.Application.Contracts;
using MarcakiService.Application.Contracts.Responses;
using MarcakiService.Domain.Events.Provider;
using MarcakiService.Domain.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MarcakiService.Application.Controllers;

[ApiController]
[Route("api/v1/provider")]
public class ProviderController : Controller
{
    private readonly IMediator _mediatR;
    private readonly IProviderRepository _repository;
    private readonly IAggregateRepository _aggregateRepository;

    public ProviderController(IMediator mediator, IProviderRepository repository, IAggregateRepository aggregateRepository)
    {
        _mediatR = mediator;
        _repository = repository;
        _aggregateRepository = aggregateRepository;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateProvider([FromBody] CreateProviderRequest request)
    {
        var validationResult = request.Validate();
        if (validationResult.IsValid == false)
        {
            return new BadRequestObjectResult(new InvalidRequestResponse(validationResult));
        }
        await _mediatR.Send(request.GetCommand());
        return Accepted();
    }

    [HttpGet("events")]
    public IActionResult GetEventProviders()
    {
        var response = _aggregateRepository.GetEvents()
            .Select(x => new EventResponse(JsonConvert.DeserializeObject<ProviderCreated>(x.Payload)!, x.EventKey, x.EventType));
        return new OkObjectResult(response);
    }

    [HttpGet("")]
    public IActionResult GetProviders()
    {
        var response = _repository.GetAll();
        return new OkObjectResult(response);
    }
}