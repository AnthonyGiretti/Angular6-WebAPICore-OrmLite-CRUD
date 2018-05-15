namespace Nexus.Cqrs.Events.Handlers
{
    using System;
    using System.Threading.Tasks;

    public class DelegateEventHandler<TEvent> : BaseEventHandler<TEvent> where TEvent : IEvent
    {
        private readonly Func<TEvent, Task> _handle;

        public DelegateEventHandler(Func<TEvent, Task> handle)
        {
            this._handle = handle;
        }

        public override Task Handle(TEvent @event)
        {
            return this._handle(@event);
        }
    }
}