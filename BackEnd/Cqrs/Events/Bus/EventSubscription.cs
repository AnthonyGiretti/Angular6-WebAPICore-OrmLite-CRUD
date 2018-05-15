namespace Cqrs.Events.Bus
{
    using System;
    using Cqrs.Events.Handlers;

    public class EventSubscription<TEvent> : IEventSubscription<TEvent> where TEvent : IEvent
    {
        public string SubscriptionId { get; set; }
        public IEventHandler<TEvent> Handler { get; set; }
        IEventHandler IEventSubscription.Handler => this.Handler;
    }
}