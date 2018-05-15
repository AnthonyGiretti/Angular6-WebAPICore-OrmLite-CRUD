namespace Nexus.Cqrs.Queries.Paged
{
    using System;

    public sealed class QueryPage
    {
        public QueryPage(int skip, int take)
        {
            if (skip < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(skip)} cannot be negative");
            }

            if (take < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(take)} cannot be negative");
            }

            this.Skip = skip;
            this.Take = take;
        }

        public int Skip { get; }
        public int Take { get; }
    }
}