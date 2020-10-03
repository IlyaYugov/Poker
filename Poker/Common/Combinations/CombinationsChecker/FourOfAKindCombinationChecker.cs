using System.Linq;

namespace Common.Combinations.CombinationsChecker
{
    public class FourOfAKindCombinationChecker : ICombinationChecker
    {
        public bool Check(Card[] cards)
        {
            return PairHelper.GetCountSameRankCard(cards).Contains(4);
        }
    }
}