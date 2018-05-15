namespace Nexus.Cqrs.Queries
{
    using System;

    // ReSharper disable once UnusedTypeParameter
    // Disabled as code is easier to read when queries declare
    // their return types.
    public interface IQuery<out TResult>
    {
        Guid QueryId { get; }
    }
}