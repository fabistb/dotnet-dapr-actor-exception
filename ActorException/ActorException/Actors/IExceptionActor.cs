using Dapr.Actors;

namespace ActorException.Actors;

public interface IExceptionActor : IActor
{
    Task ExceptionExample();
}