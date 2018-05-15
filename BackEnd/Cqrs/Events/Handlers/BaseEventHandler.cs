namespace Nexus.Cqrs.Events.Handlers
{
    using System;
    using System.Threading.Tasks;
    using Nexus.Cqrs.Events.Exceptions;

    public abstract class BaseEventHandler<TEvent> : IEventHandler<TEvent> where TEvent : IEvent
    {
        public Type HandledType => typeof(TEvent);

        public abstract Task Handle(TEvent @event);

        public async Task Handle(IEvent @event)
        {
            if (!(@event is TEvent tEvent))
            {
                throw new WrongEventTypeException(@event);
            }

            await this.Handle(tEvent);
        }
    }
}