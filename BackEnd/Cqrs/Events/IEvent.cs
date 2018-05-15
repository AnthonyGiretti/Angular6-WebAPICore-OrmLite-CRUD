namespace Cqrs.Events
{
    using System;

    public interface IEvent
    {
        Guid EventId { get; }
    }
}