using Dapr.Actors;
using Dapr.Actors.Client;

namespace ActorException.Infrastructure;

public class ActorFactory<TActor> : IActorFactory<TActor>
    where TActor : IActor
{
    public TActor CreateActor(string actorId)
    {
        var actorIds = new ActorId(actorId);
        var actorTypeName = typeof(TActor).Name.Substring(1);

        return ActorProxy.Create<TActor>(actorIds, actorTypeName);
    }
}