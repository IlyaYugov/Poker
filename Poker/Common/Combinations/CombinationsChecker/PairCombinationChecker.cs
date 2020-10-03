using System.Linq;

namespace Common.Combinations.CombinationsChecker
{
    public class PairCombinationChecker : ICombinationChecker
    {
        public bool Check(Card[] cards)
        {
            return PairHelper.GetCountSameRankCard(cards).Contains(2);
        }
    }
}