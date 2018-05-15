namespace Nexus.Cqrs.Events.Bus
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Nexus.Cqrs.Events.Handlers;

    public class InMemoryEventBus : IEventBus
    {
        private readonly ConcurrentDictionary<Type, ICollection<IEventSubscription>> _subscriptionsByEventType;

        public InMemoryEventBus()
        {
            this._subscriptionsByEventType = new ConcurrentDictionary<Type, ICollection<IEventSubscription>>();
        }

        public async Task Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {
            // Retrieve subscription list atomically.
            if (this._subscriptionsByEventType.TryGetValue(typeof(TEvent), out var subscriptions))
            {
                lock (subscriptions)
                {
                    // Make a copy to prevent lock contention.
                    subscriptions = subscriptions.ToList();
                }

                foreach (var subscription in subscriptions)
                {
                    var genericSubscription = (IEventSubscription<TEvent>) subscription;
                    await genericSubscription.Handler.Handle(@event);
                }
            }
        }

        public async Task Publish<TEvent>(IEnumerable<TEvent> events) where TEvent : IEvent
        {
            foreach (var @event in events)
            {
                await this.Publish(@event);
            }
        }

        public Task<IEventSubscription<TEvent>> Subscribe<TEvent>(IEventHandler<TEvent> handler) where TEvent : IEvent
        {
            return this.Subscribe(Guid.NewGuid().ToString(), handler);
        }

        public Task<IEventSubscription<TEvent>> Subscribe<TEvent>(string subscriptionId, IEventHandler<TEvent> handler) where TEvent : IEvent
        {
            // Retrieve subscription list atomically.
            var subscriptions = this._subscriptionsByEventType.GetOrAdd(typeof(TEvent), new List<IEventSubscription>());

            // Create a new subscription to this event bus.
            var subscription = new EventSubscription<TEvent>
            {
                SubscriptionId = subscriptionId,
                Handler = handler
            };

            // Add it to all subscriptions.
            lock (subscriptions)
            {
                subscriptions.Add(subscription);
            }

            return Task.FromResult<IEventSubscription<TEvent>>(subscription);
        }

        public Task Unsubscribe<TEvent>(IEventSubscription<TEvent> subscription) where TEvent : IEvent
        {
            if (this._subscriptionsByEventType.TryGetValue(typeof(TEvent), out var subscriptions))
            {
                lock (subscriptions)
                {
                    subscriptions.Remove(subscription);
                }
            }

            return Task.CompletedTask;
        }
    }
}