using ActorException.Services;
using Microsoft.AspNetCore.Mvc;

namespace ActorException.Controllers;

[Route("api/[controller]")]
public class ServiceController : ControllerBase
{
    private readonly IExceptionService _service;

    public ServiceController(IExceptionService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        await _service.Example();
        
        return Ok();
    }
}