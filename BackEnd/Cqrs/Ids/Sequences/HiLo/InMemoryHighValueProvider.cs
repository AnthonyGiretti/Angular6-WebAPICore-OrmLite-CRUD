namespace Nexus.Cqrs.Ids.Sequences.HiLo
{
    public class InMemoryHighValueProvider : IHighValueProvider
    {
        public InMemoryHighValueProvider()
        {
            this.Current = 0;
        }

        public int Current { get; private set; }

        public int Next()
        {
            return ++this.Current;
        }
    }
}