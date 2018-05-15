namespace Cqrs.Ids.Sequences
{
    public interface INumericSequence
    {
        long Next();
    }
}