namespace Common.Combinations.CombinationsChecker
{
    public class StraightFlushCombinationChecker : ICombinationChecker
    {
        private readonly FlushCombinationChecker _flushCombinationChecker;
        private readonly StraightCombinationChecker _straightCombinationChecker;

        public StraightFlushCombinationChecker(FlushCombinationChecker flushCombinationChecker, StraightCombinationChecker straightCombinationChecker)
        {
            _flushCombinationChecker = flushCombinationChecker;
            _straightCombinationChecker = straightCombinationChecker;
        }

        public bool Check(Card[] cards)
        {
            return _flushCombinationChecker.Check(cards) && _straightCombinationChecker.Check(cards);
        }
    }
}