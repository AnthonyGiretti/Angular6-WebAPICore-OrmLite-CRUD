namespace Nexus.Cqrs.Queries.Exceptions
{
    public class WrongQueryTypeException : QueryException
    {
        public WrongQueryTypeException(IQuery<object> query)
            : base(query.QueryId, "wrong-query-type", $"The query handler cannot handle queries of type {query.GetType()}.")
        {
        }
    }
}