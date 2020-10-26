using System.Collections.Generic;
using System.Linq;
using Common;

namespace StatisticsCalculator.Calculators
{
    public class TotalEnterTurnCalculator: IStatisticCalculator<int>
    {
        public int Calculate(Player player)
        {
            var playerFlopRounds = player.PlayerGameSnapshots.SelectMany(ps => ps.StartedRounds)
                .Where(round => round.RoundType == RoundType.Turn);

            return playerFlopRounds.Count();
        }
    }
}