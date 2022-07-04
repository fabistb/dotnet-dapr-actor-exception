using ActorException.Actors;
using ActorException.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ActorException.Controllers;

[Route("api/[controller]")]
public class ActorController : ControllerBase
{
    private readonly IActorFactory<IExceptionActor> _actorFactory;

    public ActorController(IActorFactory<IExceptionActor> actorFactory)
    {
        _actorFactory = actorFactory;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var actor = _actorFactory.CreateActor(Guid.NewGuid().ToString());
        await actor.ExceptionExample();
        
        return Ok();
    }
}