namespace Nexus.Cqrs.Ids.Sequences.HiLo
{
    using Microsoft.Extensions.Logging;

    public class HiLoNumericSequence : INumericSequence
    {
        private readonly ILogger<HiLoNumericSequence> _logger;
        private readonly IHighValueProvider _highValueProvider;
        private readonly ILowValueProvider _lowValueProvider;

        public HiLoNumericSequence(ILogger<HiLoNumericSequence> logger, IHighValueProvider highValueProvider, ILowValueProvider lowValueProvider)
        {
            this._logger = logger;
            this._highValueProvider = highValueProvider;
            this._lowValueProvider = lowValueProvider;
        }

        public long Next()
        {
            var high = -1;
            var low = -1;
            var successful = false;

            while (!successful)
            {
                lock (this)
                {
                    // Acquire the mutex then acquire both low and high value.
                    // This is the nominal case; we lock for a minimal
                    // amount of time, as acquiring the current high value and
                    // the next low value are small local operations.

                    high = this._highValueProvider.Current;
                    successful = this._lowValueProvider.TryNext(out low);

                    if (!successful)
                    {
                        // Reset low value and retrieve next high value.
                        // This is potentially a long operation as retrieving
                        // a new high value might incur a network operation.

                        this._highValueProvider.Next();
                        this._lowValueProvider.Reset();
                    }
                }
            }

            // High and low value retrieved, create the next value.
            return this.CreateAndLogNext(high, low);
        }

        private long CreateAndLogNext(int high, int low)
        {
            var value = this.CreateNext(high, low);
            this._logger.LogDebug($"Value generated from hilo value={value} low={low} high={high}");
            return value;
        }

        private long CreateNext(int high, int low)
        {
            // ReSharper disable ArrangeRedundantParentheses
            return ((long) high * this._lowValueProvider.Max) + low + 1;
        }
    }
}