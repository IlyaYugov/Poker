using System.Linq;

namespace Common.Combinations.CombinationsChecker
{
    public class ThreeOfAKindCombinationChecker : ICombinationChecker
    {
        public bool Check(Card[] cards)
        {
            return PairHelper.GetCountSameRankCard(cards).Contains(3);
        }
    }
}