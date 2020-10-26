using System;
using System.Linq;
using Common;

namespace StatisticsCalculator.Calculators
{
    public class WinnedBlindsCalculator : WinnedMoneyStatisticBase, IStatisticCalculator<double>
    {
        public double Calculate(Player player)
        {
            var winnedMoney = player.PlayerGameSnapshots
                .Sum(GetWinnedBlinds);

            return winnedMoney;
        }

        private double GetWinnedBlinds(PlayerGameSnapshot playerGameSnapshot)
        {
            var winnedBlinds = (playerGameSnapshot.CollectedMoney - playerGameSnapshot.GaveMoneyToBank) / playerGameSnapshot.Game.BigBlind;

            return winnedBlinds;
        }
    }
}