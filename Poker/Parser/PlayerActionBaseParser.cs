using System.Collections.Generic;
using System.Linq;
using Common;

namespace Parser
{
    public class PlayerActionBaseParser
    {
        private readonly MoneyBaseParser _moneyBaseParser;

        public PlayerActionBaseParser(MoneyBaseParser moneyBaseParser)
        {
            _moneyBaseParser = moneyBaseParser;
        }

        public PlayerAction Parse(List<PlayerGameSnapshot> roundPlayers, ActionType actionType, string line)
        {
            var player = roundPlayers.FirstOrDefault(p => line.Contains(p.Player.NickName));
            if(player == null)
                return new PlayerAction();

            var action = new PlayerAction
            {
                PlayerGameSnapshot = player,
                ActionType = actionType,
                Money = _moneyBaseParser.Parse(line, '[')
            };

            return action;
        }
    }
}