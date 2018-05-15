namespace Nexus.Cqrs.Queries.Paged
{
    using System.Collections.Generic;

    public interface IPagedQuery<out TResult> : IQuery<IEnumerable<TResult>>
    {
        QueryPage Page { get; set; }
    }
}