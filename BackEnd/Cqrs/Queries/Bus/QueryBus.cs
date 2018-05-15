namespace Cqrs.Queries.Bus
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Cqrs.Queries.Exceptions;
    using Cqrs.Queries.Handlers;
    using Cqrs.Queries.Paged;

    public class QueryBus : IQueryBus
    {
        private readonly IDictionary<Type, IQueryHandler> _handlersByQueryType;

        public QueryBus(IEnumerable<IQueryHandler> queryHandlers)
        {
            this._handlersByQueryType = queryHandlers.ToDictionary(x => x.HandledType, x => x);
        }

        public async Task<TResult> Execute<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            if (!this._handlersByQueryType.TryGetValue(query.GetType(), out var queryHandler))
            {
                throw new NoQueryHandlersException((IQuery<object>) query);
            }

            return (TResult) await queryHandler.Handle((IQuery<object>) query);
        }

        public async Task<IEnumerable<TResult>> ExecutePaged<TPagedQuery, TResult>(TPagedQuery query)
            where TPagedQuery : IPagedQuery<TResult>
        {
            return await this.Execute<TPagedQuery, IEnumerable<TResult>>(query);
        }
    }
}