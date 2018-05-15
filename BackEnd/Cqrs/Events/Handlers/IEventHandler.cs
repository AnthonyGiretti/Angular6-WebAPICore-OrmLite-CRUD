namespace Nexus.Cqrs.Events.Handlers
{
    using System;
    using System.Threading.Tasks;

    public interface IEventHandler
    {
        Type HandledType { get; }

        Task Handle(IEvent @event);
    }

    public interface IEventHandler<in TEvent> : IEventHandler where TEvent : IEvent
    {
        Task Handle(TEvent @event);
    }
}