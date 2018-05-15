namespace Cqrs.Queries.Bus
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Cqrs.Queries.Paged;

    public interface IQueryBus
    {
        Task<TResult> Execute<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;

        Task<IEnumerable<TResult>> ExecutePaged<TPagedQuery, TResult>(TPagedQuery query)
            where TPagedQuery : IPagedQuery<TResult>;
    }
}