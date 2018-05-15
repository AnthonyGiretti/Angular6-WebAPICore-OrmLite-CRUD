namespace Nexus.Cqrs.Ids.Sequences
{
    public interface INumericSequence
    {
        long Next();
    }
}