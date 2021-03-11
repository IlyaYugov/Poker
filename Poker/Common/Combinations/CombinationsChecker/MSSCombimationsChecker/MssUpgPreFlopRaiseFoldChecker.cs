using System.Linq;

namespace Common.Combinations.CombinationsChecker.MSSCombimationsChecker
{
    public class MssUpgPreFlopRaiseFoldChecker
    {
        private readonly PairCombinationChecker _pairCombinationChecker;

        public MssUpgPreFlopRaiseFoldChecker(PairCombinationChecker pairCombinationChecker)
        {
            _pairCombinationChecker = pairCombinationChecker;
        }

        public bool Check(Card[] cards)
        {
            if (cards.All(c => c.CardRank >= CardRank.Eight) &&
                _pairCombinationChecker.Check(cards) ||

                cards.Any(c => c.CardRank == CardRank.Ace) &&
                (cards.Any(c => c.CardRank > CardRank.Jack) ||
                 cards.Any(c => c.CardRank == CardRank.Ten) &&
                 cards.GroupBy(c => c.CardSuit).Count() == 1) ||

                cards.All(c => c.CardRank >= CardRank.Queen))
                return true;

            return false;
        }
    }
}