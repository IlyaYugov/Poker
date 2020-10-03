using Common.Combinations.CombinationsChecker;

namespace Common
{
    public class CombinationTypeGetter
    {
        private readonly StraightFlushCombinationChecker _straightFlushCombinationChecker;
        private readonly StraightCombinationChecker _straightCombinationChecker;
        private readonly FlushCombinationChecker _flushCombinationChecker;
        private readonly FourOfAKindCombinationChecker _fourOfAKindCombinationChecker;
        private readonly FullHouseCombinationChecker _fullHouseCombinationCheckerCombinationChecker;
        private readonly PairCombinationChecker _pairCombinationChecker;
        private readonly ThreeOfAKindCombinationChecker _threeOfAKindCombinationChecker;
        private readonly TwoPairCombinationChecker _twoPairCombinationChecker;

        public CombinationTypeGetter(
            StraightFlushCombinationChecker straightFlushCombinationChecker, 
            StraightCombinationChecker straightCombinationChecker,
            FlushCombinationChecker flushCombinationChecker, 
            FourOfAKindCombinationChecker fourOfAKindCombinationChecker, 
            FullHouseCombinationChecker fullHouseCombinationCheckerCombinationChecker, 
            PairCombinationChecker pairCombinationChecker, 
            ThreeOfAKindCombinationChecker threeOfAKindCombinationChecker, 
            TwoPairCombinationChecker twoPairCombinationChecker)
        {
            _straightCombinationChecker = straightCombinationChecker;
            _flushCombinationChecker = flushCombinationChecker;
            _fourOfAKindCombinationChecker = fourOfAKindCombinationChecker;
            _fullHouseCombinationCheckerCombinationChecker = fullHouseCombinationCheckerCombinationChecker;
            _pairCombinationChecker = pairCombinationChecker;
            _threeOfAKindCombinationChecker = threeOfAKindCombinationChecker;
            _twoPairCombinationChecker = twoPairCombinationChecker;
            _straightFlushCombinationChecker = straightFlushCombinationChecker;
        }

        public CombinationType GetCombinationType(Card[] cards)
        {
            if (_straightFlushCombinationChecker.Check(cards))
                return CombinationType.StraightFlush;

            if (_fourOfAKindCombinationChecker.Check(cards))
                return CombinationType.FourOfAKind;

            if (_fullHouseCombinationCheckerCombinationChecker.Check(cards))
                return CombinationType.FullHouse;

            if (_flushCombinationChecker.Check(cards))
                return CombinationType.Flush;

            if (_straightCombinationChecker.Check(cards))
                return CombinationType.Straight;

            if (_threeOfAKindCombinationChecker.Check(cards))
                return CombinationType.ThreeOfAKind;

            if (_twoPairCombinationChecker.Check(cards))
                return CombinationType.TwoPairs;

            if (_pairCombinationChecker.Check(cards))
                return CombinationType.Pair;

            return CombinationType.Kiker;

        }
    }
}