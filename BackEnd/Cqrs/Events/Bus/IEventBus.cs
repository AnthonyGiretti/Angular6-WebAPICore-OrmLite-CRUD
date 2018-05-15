namespace Cqrs.Events.Bus
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Cqrs.Events.Handlers;

    public interface IEventBus
    {
        Task Publish<TEvent>(TEvent @event) where TEvent : IEvent;
        Task Publish<TEvent>(IEnumerable<TEvent> events) where TEvent : IEvent;
        Task<IEventSubscription<TEvent>> Subscribe<TEvent>(IEventHandler<TEvent> handler) where TEvent : IEvent;
        Task<IEventSubscription<TEvent>> Subscribe<TEvent>(string subscriptionId, IEventHandler<TEvent> handler) where TEvent : IEvent;
        Task Unsubscribe<TEvent>(IEventSubscription<TEvent> subscription) where TEvent : IEvent;
    }
}