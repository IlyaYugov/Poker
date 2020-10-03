using System.Collections.Generic;
using Common;
using StatisticsCalculator.Calculators;

namespace StatisticsCalculator
{
    public class PlayerStatisticsCalculator :IStatisticCalculator<PlayerStatistic>
    {
        private readonly TotalGamesCalculator _totalGamesCalculator;
        private readonly TotalEnterFlopCalculator _totalEnterFlopCalculator;
        private readonly TotalEnterTurnCalculator _totalEnterTurnCalculator;
        private readonly TotalEnterRiverCalculator _totalEnterRiverCalculator;
        private readonly TotalEnterShowDownCalculator _totalEnterShowDownCalculator;
        private readonly WinnedMoneyCalculator _winnedMoneyCalculator;
        private readonly WinnedBlindsCalculator _winnedBlindsCalculator;

        public PlayerStatisticsCalculator(TotalGamesCalculator totalGamesCalculator,
            TotalEnterFlopCalculator totalEnterFlopCalculator, 
            TotalEnterTurnCalculator totalEnterTurnCalculator, 
            TotalEnterRiverCalculator totalEnterRiverCalculator, 
            TotalEnterShowDownCalculator totalEnterShowDownCalculator, 
            WinnedMoneyCalculator winnedMoneyCalculator, 
            WinnedBlindsCalculator winnedBlindsCalculator)
        {
            _totalGamesCalculator = totalGamesCalculator;
            _totalEnterFlopCalculator = totalEnterFlopCalculator;
            _totalEnterTurnCalculator = totalEnterTurnCalculator;
            _totalEnterRiverCalculator = totalEnterRiverCalculator;
            _totalEnterShowDownCalculator = totalEnterShowDownCalculator;
            _winnedMoneyCalculator = winnedMoneyCalculator;
            _winnedBlindsCalculator = winnedBlindsCalculator;
        }

        public PlayerStatistic Calculate(Player player, List<Game> playerGames)
        {
            var playerStatistics = new PlayerStatistic
            {
                Player = player,
                TotalGames = _totalGamesCalculator.Calculate(player, playerGames),
                TotalEnterFlop = _totalEnterFlopCalculator.Calculate(player, playerGames),
                TotalEnterTurn = _totalEnterTurnCalculator.Calculate(player, playerGames),
                TotalEnterRiver = _totalEnterRiverCalculator.Calculate(player, playerGames),
                TotalEnterShowDown = _totalEnterShowDownCalculator.Calculate(player, playerGames),
                WinnedMoney = _winnedMoneyCalculator.Calculate(player, playerGames),
                WinnedBlinds = _winnedBlindsCalculator.Calculate(player, playerGames)
            };

            return playerStatistics;
        }
    }
}
