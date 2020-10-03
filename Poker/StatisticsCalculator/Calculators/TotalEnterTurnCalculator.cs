using System.Collections.Generic;
using System.Linq;
using Common;

namespace StatisticsCalculator.Calculators
{
    public class TotalEnterTurnCalculator :IStatisticCalculator<int>
    {
        public int Calculate(Player player, List<Game> playerGames)
        {
            var playerFlopRounds = player.StartedRounds
                .Where(round => round.RoundType == RoundType.Turn);

            return playerFlopRounds.Count();
        }
    }
}