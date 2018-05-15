namespace Nexus.Cqrs.Queries.Exceptions
{
    using System;

    public class QueryException : SystemException
    {
        public QueryException(Guid queryId, string errorCode, string message)
            : this(queryId, errorCode, message, null)
        {
        }

        public QueryException(Guid queryId, string errorCode, string message, Exception innerException)
            : base(message, innerException)
        {
            this.QueryId = queryId;
            this.ErrorCode = errorCode;
        }

        public Guid QueryId { get; }
        public string ErrorCode { get; }
    }
}