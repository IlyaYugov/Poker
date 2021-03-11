using System.Linq;

namespace Common.Combinations.CombinationsChecker.MSSCombimationsChecker
{
    public class MssUpgPreFlopRaiseAllInChecker
    {
        private readonly PairCombinationChecker _pairCombinationChecker;

        public MssUpgPreFlopRaiseAllInChecker(PairCombinationChecker pairCombinationChecker)
        {
            _pairCombinationChecker = pairCombinationChecker;
        }

        public bool Check(Card[] cards)
        {
            if (cards.All(c => c.CardRank >= CardRank.King) ||
                cards.All(c => c.CardRank == CardRank.Queen))
                return true;

            return false;
        }
    }
}