using System.Linq;
using System.Threading.Tasks;
using MarcakiService.Application.Contracts;
using MarcakiService.Application.Contracts.Responses;
using MarcakiService.Domain.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MarcakiService.Application.Controllers;

[ApiController]
[Route("api/v1/provider")]
public class ProviderController : Controller
{
    private IMediator _mediatR;
    private IProviderRepository _repository;
    private IAggregateRepository _aggregateRepository;

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

    [HttpGet]
    public IActionResult GetProviders()
    {
        var response = _aggregateRepository.GetEvents()
            .Select(x => new EventResponse((x.AggregateType) JsonConvert.DeserializeObject(x.Payload), x.EventKey));
        return new OkObjectResult(response);
    }
}