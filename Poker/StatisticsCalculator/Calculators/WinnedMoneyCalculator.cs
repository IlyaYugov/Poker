using System.Collections.Generic;
using System.Linq;
using Common;

namespace StatisticsCalculator.Calculators
{
    public class WinnedMoneyCalculator : WinnedMoneyStatisticBase, IStatisticCalculator<double>
    {
        public double Calculate(Player player)
        {
            var winnedMoney = player.PlayerGameSnapshots
                .Sum(ps => ps.CollectedMoney - ps.GaveMoneyToBank);

            return winnedMoney;
        }
    }
}