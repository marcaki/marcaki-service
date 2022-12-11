using MarcakiService.Application.Contracts;
using MarcakiService.Application.Contracts.Responses;
using MarcakiService.Domain.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MarcakiService.Application.Controllers;

[Route("api/v1/provider")]
public class ProviderController : Controller
{
    private IMediator _mediatR;
    private IProviderRepository _repository;

    public ProviderController(IMediator mediator, IProviderRepository repository)
    {
        _mediatR = mediator;
        _repository = repository;
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
        return new OkObjectResult(_repository.GetAll());
    }
}