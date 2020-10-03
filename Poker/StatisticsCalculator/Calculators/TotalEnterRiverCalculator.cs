using System.Collections.Generic;
using System.Linq;
using Common;

namespace StatisticsCalculator.Calculators
{
    public class TotalEnterRiverCalculator : IStatisticCalculator<int>
    {
        public int Calculate(Player player, List<Game> playerGames)
        {
            /*var playerFlopRounds = playerGames
                .SelectMany(game => game.Rounds.Where(r => r.RoundType == RoundType.River))
                .Where(round => round.StartedPlayers.Any(p => p.Id == player.Id));*/

            var playerFlopRounds = player.StartedRounds
                .Where(round => round.RoundType == RoundType.River);

            return playerFlopRounds.Count();
        }
    }
}