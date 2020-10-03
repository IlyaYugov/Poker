using System.Collections.Generic;
using System.Linq;
using Common;

namespace StatisticsCalculator.Calculators
{
    public class WinnedBlindsCalculator : WinnedMoneyStatisticBase, IStatisticCalculator<int>
    {
        public int Calculate(Player player, List<Game> playerGames)
        {
            var winnedMoney = player.StartedRounds
                .Sum(round=> (int)(GetWinnedMoneyInRound(round)/round.Game.BigBlind) );

            return winnedMoney;
        }
    }
}