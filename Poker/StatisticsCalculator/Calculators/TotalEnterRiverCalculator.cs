﻿using System.Collections.Generic;
using System.Linq;
using Common;

namespace StatisticsCalculator.Calculators
{
    public class TotalEnterRiverCalculator : IStatisticCalculator<int>
    {
        public int Calculate(Player player)
        {
            var playerFlopRounds = player.PlayerGameSnapshots.SelectMany(ps => ps.StartedRounds)
                .Where(round => round.RoundType == RoundType.River);

            return playerFlopRounds.Count();
        }
    }
}