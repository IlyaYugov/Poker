using System.Linq;
using Common;

namespace StatisticsCalculator.Calculators
{
    public class WinnedMoneyStatisticBase
    {
        internal double GetWinnedMoneyInRound(Round round)
        {
            return round.PlayerActions.Sum(GetWinnedMoneyByAction);
        }

        internal double GetWinnedMoneyByAction(PlayerAction action)
        {
            switch (action.ActionType)
            {
                case ActionType.Call:
                case ActionType.Raise:
                    return -action.Money;
                case ActionType.Collected:
                    return action.Money;
                default:
                    return 0;
            }
        }
    }
}