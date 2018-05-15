namespace Cqrs.Queries.Exceptions
{
    public class NoQueryHandlersException : QueryException
    {
        public NoQueryHandlersException(IQuery<object> query)
            : base(query.QueryId, "no-query-handlers", $"The query of type {query.GetType()} cannot .")
        {
        }
    }
}