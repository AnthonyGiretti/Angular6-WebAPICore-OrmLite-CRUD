namespace Nexus.Cqrs.Queries.Paged
{
    using System.Collections.Generic;

    public class BasePagedQuery<TResult> : BaseQuery<IEnumerable<TResult>>, IPagedQuery<TResult>
    {
        public QueryPage Page { get; set; }
    }
}