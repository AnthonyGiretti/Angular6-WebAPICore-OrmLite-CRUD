namespace Nexus.Cqrs.Ids.Guids
{
    using System;

    public class GuidIdGenerator : BaseIdGenerator<Guid>
    {
        public override Guid Generate()
        {
            return Guid.NewGuid();
        }
    }
}