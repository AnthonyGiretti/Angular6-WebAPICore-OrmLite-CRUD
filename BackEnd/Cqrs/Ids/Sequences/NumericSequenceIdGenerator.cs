namespace Nexus.Cqrs.Ids.Sequences
{
    public class NumericSequenceIdGenerator : BaseIdGenerator<long>
    {
        private readonly INumericSequence _numericSequence;

        public NumericSequenceIdGenerator(INumericSequence numericSequence)
        {
            this._numericSequence = numericSequence;
        }

        public override long Generate()
        {
            return this._numericSequence.Next();
        }
    }
}