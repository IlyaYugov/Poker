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

        public PlayerAction Parse(Player[] roundPlayers, ActionType actionType, string line)
        {
            var player = roundPlayers.First(p => line.Contains(p.NickName));
            var action = new PlayerAction
            {
                Player = player,
                ActionType = actionType,
                Money = _moneyBaseParser.Parse(line, '[')
            };

            return action;
        }
    }
}