namespace Nexus.Cqrs.Ids.Sequences.HiLo
{
    public interface ILowValueProvider
    {
        int Max { get; }
        bool TryNext(out int value);
        void Reset();
    }
}