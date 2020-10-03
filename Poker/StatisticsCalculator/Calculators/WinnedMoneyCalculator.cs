using System.Collections.Generic;
using System.Linq;
using Common;

namespace StatisticsCalculator.Calculators
{
    public class WinnedMoneyCalculator : WinnedMoneyStatisticBase, IStatisticCalculator<double>
    {
        public double Calculate(Player player, List<Game> playerGames)
        {
            var winnedMoney = player.StartedRounds
                .Sum(GetWinnedMoneyInRound);

            return winnedMoney;
        }
    }
}