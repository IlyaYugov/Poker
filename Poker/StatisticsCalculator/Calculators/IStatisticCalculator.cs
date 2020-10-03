using System.Collections.Generic;
using Common;

namespace StatisticsCalculator.Calculators
{
    public interface IStatisticCalculator<TStatisticType>
    {
        TStatisticType Calculate(Player player, List<Game> playerGames);
    }
}