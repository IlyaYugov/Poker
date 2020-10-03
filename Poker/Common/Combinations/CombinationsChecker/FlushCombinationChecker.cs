using System.Linq;

namespace Common.Combinations.CombinationsChecker
{
    public class FlushCombinationChecker : ICombinationChecker
    {
        public bool Check(Card[] cards)
        {
            var gameSuits = cards.GroupBy(a => a.CardSuit);

            if (gameSuits.Any(suit => suit.Count() >= 5))
                return true;

            return false;
        }
    }
}