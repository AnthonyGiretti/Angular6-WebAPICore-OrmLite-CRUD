namespace Cqrs.Queries.Paged.Handlers
{
    using System.Collections.Generic;
    using Cqrs.Queries.Handlers;

    public abstract class
        BasePagedQueryHandler<TPagedQuery, TResult> : BaseQueryHandler<TPagedQuery, IEnumerable<TResult>>
        where TPagedQuery : IPagedQuery<TResult>
    {
    }
}