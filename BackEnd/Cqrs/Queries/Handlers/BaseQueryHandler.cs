namespace Nexus.Cqrs.Queries.Handlers
{
    using System;
    using System.Threading.Tasks;
    using Nexus.Cqrs.Queries.Exceptions;

    public abstract class BaseQueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        public Type HandledType => typeof(TQuery);

        public abstract Task<TResult> Handle(TQuery query);

        public async Task<object> Handle(IQuery<object> query)
        {
            if (!(query is TQuery tQuery))
            {
                throw new WrongQueryTypeException(query);
            }

            return await this.Handle(tQuery);
        }
    }
}