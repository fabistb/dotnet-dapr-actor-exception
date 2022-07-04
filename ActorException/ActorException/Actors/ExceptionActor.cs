using Dapr.Actors.Runtime;

namespace ActorException.Actors;

public class ExceptionActor : Actor, IExceptionActor
{
    public ExceptionActor(ActorHost host) 
        : base(host)
    {
    }

    public Task ExceptionExample()
    {
        throw new NotImplementedException();
    }
}