using System.Linq;

namespace Common
{
    public class PairHelper
    {
        public static int[] GetCountSameRankCard(Card[] cards) =>
            cards
                .GroupBy(card => (int)card.CardRank)
                .Select(groupCard => groupCard.Count())
                .ToArray();
    }
}
