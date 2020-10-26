using System.Collections.Generic;
using Common;

namespace StatisticsCalculator.Calculators
{
    public class TotalGamesCalculator :IStatisticCalculator<int>
    {
        public int Calculate(Player player)
        {
            return player.Games.Count;
        }
    }
}