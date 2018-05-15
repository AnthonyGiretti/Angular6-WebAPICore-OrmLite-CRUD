namespace Cqrs.Ids
{
    public interface IIdGenerator
    {
        object Generate();
    }

    public interface IIdGenerator<out TIdentifier> : IIdGenerator
    {
        new TIdentifier Generate();
    }
}