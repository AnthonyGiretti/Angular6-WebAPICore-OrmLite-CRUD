namespace Cqrs.Events.Exceptions
{
    public class WrongEventTypeException : EventException
    {
        public WrongEventTypeException(IEvent @event)
            : base(@event.EventId, "wrong-event-type", $"The event handler cannot handle events of type {@event.GetType()}.")
        {
        }
    }
}