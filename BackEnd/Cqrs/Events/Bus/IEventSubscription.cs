namespace Cqrs.Events.Bus
{
    using Cqrs.Events.Handlers;

    public interface IEventSubscription
    {
        string SubscriptionId { get; }
        IEventHandler Handler { get; }
    }

    public interface IEventSubscription<in TEvent> : IEventSubscription where TEvent : IEvent
    {
        new IEventHandler<TEvent> Handler { get; }
    }
}