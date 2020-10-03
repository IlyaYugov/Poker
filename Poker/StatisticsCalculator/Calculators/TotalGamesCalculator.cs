using System.Collections.Generic;
using Common;

namespace StatisticsCalculator.Calculators
{
    public class TotalGamesCalculator :IStatisticCalculator<int>
    {
        public int Calculate(Player player, List<Game> playerGames)
        {
            return playerGames.Count;
        }
    }
}