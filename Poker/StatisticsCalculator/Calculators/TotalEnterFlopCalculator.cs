using System.Collections.Generic;
using System.Linq;
using Common;

namespace StatisticsCalculator.Calculators
{
    public class TotalEnterFlopCalculator: IStatisticCalculator<int>
    {
        public int Calculate(Player player, List<Game> playerGames)
        {
            var playerFlopRounds = player.StartedRounds
                .Where(round => round.RoundType == RoundType.Flop);

            return playerFlopRounds.Count();
        }
    }
}