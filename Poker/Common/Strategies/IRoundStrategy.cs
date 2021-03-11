using System.Collections.Generic;

namespace Common.Strategies
{
    public interface IRoundStrategy
    {
        ActionType GetActionByGameSituation(PlayerGameSnapshot player, Round round);
    }
}