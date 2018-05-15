namespace Cqrs.Queries.Handlers
{
    using System;
    using System.Threading.Tasks;

    public interface IQueryHandler
    {
        Type HandledType { get; }

        Task<object> Handle(IQuery<object> query);
    }

    public interface IQueryHandler<in TQuery, TResult> : IQueryHandler where TQuery : IQuery<TResult>
    {
        Task<TResult> Handle(TQuery query);
    }
}