namespace Nexus.Cqrs.Queries
{
    using System;

    public abstract class BaseQuery<TResult> : IQuery<TResult>
    {
        public Guid QueryId { get; protected set; } = Guid.NewGuid();
    }
}