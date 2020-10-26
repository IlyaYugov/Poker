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

        public PlayerStatistic Calculate(Player player)
        {
            var playerStatistics = new PlayerStatistic
            {
                PlayerGameSnapshot = player,
                TotalGames = _totalGamesCalculator.Calculate(player),
                TotalEnterFlop = _totalEnterFlopCalculator.Calculate(player),
                TotalEnterTurn = _totalEnterTurnCalculator.Calculate(player),
                TotalEnterRiver = _totalEnterRiverCalculator.Calculate(player),
                TotalEnterShowDown = _totalEnterShowDownCalculator.Calculate(player),
                WinnedMoney = _winnedMoneyCalculator.Calculate(player),
                WinnedBlinds = _winnedBlindsCalculator.Calculate(player)
            };

            return playerStatistics;
        }
    }
}
