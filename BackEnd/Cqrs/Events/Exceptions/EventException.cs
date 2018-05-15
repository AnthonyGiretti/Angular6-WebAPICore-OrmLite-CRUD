namespace Cqrs.Events.Exceptions
{
    using System;

    public class EventException : SystemException
    {
        public EventException(Guid eventId, string errorCode, string message)
            : this(eventId, errorCode, message, null)
        {
        }

        public EventException(Guid eventId, string errorCode, string message, Exception innerException)
            : base(message, innerException)
        {
            this.EventId = eventId;
            this.ErrorCode = errorCode;
        }

        public Guid EventId { get; }
        public string ErrorCode { get; }
    }
}