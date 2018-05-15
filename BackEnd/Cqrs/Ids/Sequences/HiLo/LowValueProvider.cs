namespace Nexus.Cqrs.Ids.Sequences.HiLo
{
    using System;

    public class LowValueProvider : ILowValueProvider
    {
        public LowValueProvider(int max)
        {
            if (max <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.Max = max;
            this.Current = 0;
        }

        public int Max { get; }
        public int Current { get; private set; }

        public bool TryNext(out int value)
        {
            if (this.Current == this.Max)
            {
                value = -1;
                return false;
            }

            value = this.Current++;
            return true;
        }

        public void Reset()
        {
            this.Current = 0;
        }
    }
}