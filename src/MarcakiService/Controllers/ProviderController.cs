using MarcakiService.Application.Contracts;
using MarcakiService.Application.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;

namespace MarcakiService.Application.Controllers;

[Route("api/v1/provider")]
public class ProviderController : Controller
{
    [HttpPost]
    public IActionResult CreateProvider([FromBody] CreateProviderRequest request)
    {
        var validationResult = request.Validate();
        if (validationResult.IsValid == false)
        {
            return new BadRequestObjectResult(new InvalidRequestResponse(validationResult));
        }
        return Accepted();
    }
}