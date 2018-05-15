namespace Nexus.Cqrs.Ids.Sequences.HiLo
{
    public interface IHighValueProvider
    {
        int Current { get; }
        int Next();
    }
}