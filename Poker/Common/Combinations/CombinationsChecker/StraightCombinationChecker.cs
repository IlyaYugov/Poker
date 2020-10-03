using System.Collections.Generic;
using System.Linq;

namespace Common.Combinations.CombinationsChecker
{
    public class StraightCombinationChecker : ICombinationChecker
    {
        public bool Check(Card[] cards)
        {
            var gameSuits = cards
                .Select(s => (int)s.CardRank)
                .Distinct()
                .OrderBy(s => s).ToList();

            return IsStraight(gameSuits);
        }

        private static bool IsStraight(List<int> allCards)
        {
            var controlNumber = allCards[0];
            int positiveCount = 1;

            if (controlNumber == (int)CardRank.Two && allCards.Any(c => c == (int)CardRank.Ace))
            {
                allCards.Remove((int)CardRank.Ace);
                positiveCount++;
            }

            for (int i = 1; i < allCards.Count; i++)
            {
                if (allCards[i] != controlNumber + i)
                {
                    controlNumber = allCards[i];
                    positiveCount = 0;
                }

                positiveCount++;
            }

            return positiveCount >= 5;
        }
    }
}