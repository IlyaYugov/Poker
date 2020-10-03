namespace Common.Combinations.CombinationsChecker
{
    public class FullHouseCombinationChecker : ICombinationChecker
    {
        private readonly PairCombinationChecker _pairCombinationChecker;
        private readonly ThreeOfAKindCombinationChecker _threeOfAKindCombinationChecker;

        FullHouseCombinationChecker(PairCombinationChecker pairCombinationChecker, ThreeOfAKindCombinationChecker threeOfAKindCombinationChecker)
        {
            _pairCombinationChecker = pairCombinationChecker;
            _threeOfAKindCombinationChecker = threeOfAKindCombinationChecker;
        }

        public bool Check(Card[] cards)
        {
            return _pairCombinationChecker.Check(cards) && _threeOfAKindCombinationChecker.Check(cards);
        }
    }
}