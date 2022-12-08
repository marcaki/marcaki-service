using MarcakiService.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MarcakiService.Application.Controllers;

[Route("api/v1/provider")]
public class ProviderController : Controller
{
    [HttpPost]
    public IActionResult CreateProvider([FromBody] CreateProviderRequest request)
    {
        return Accepted();
    }
}