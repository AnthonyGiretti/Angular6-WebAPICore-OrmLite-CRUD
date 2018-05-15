namespace Nexus.Cqrs.Ids
{
    public abstract class BaseIdGenerator<TIdentifier> : IIdGenerator<TIdentifier>
    {
        public abstract TIdentifier Generate();

        object IIdGenerator.Generate()
        {
            return this.Generate();
        }
    }
}