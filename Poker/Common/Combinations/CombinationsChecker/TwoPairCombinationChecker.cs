using System.Linq;

namespace Common.Combinations.CombinationsChecker
{
    public class TwoPairCombinationChecker : ICombinationChecker
    {
        public bool Check(Card[] cards)
        {
            return PairHelper.GetCountSameRankCard(cards).Count(c => c == 2) > 1;
        }
    }
}