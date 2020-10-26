using System.Collections.Generic;
using Common;

namespace Parser
{
    public class PlayerActionsBaseParser
    {
        private readonly PlayerActionBaseParser _actionBaseParser;

        public PlayerActionsBaseParser(PlayerActionBaseParser actionBaseParser)
        {
            _actionBaseParser = actionBaseParser;
        }

        public List<PlayerAction> Parse(List<PlayerGameSnapshot> roundPlayers, string[] lines, ref int lineIndex)
        {
            var actions = new List<PlayerAction>();

            while (true)
            {
                var line = lines[lineIndex];

                if (line.Contains("folds"))
                {
                    actions.Add(_actionBaseParser.Parse(roundPlayers, ActionType.Fold, line));
                }

                if (line.Contains("checks"))
                {
                    actions.Add(_actionBaseParser.Parse(roundPlayers, ActionType.Check, line));
                }

                if (line.Contains("raises") || line.Contains("bets"))
                {
                    actions.Add(_actionBaseParser.Parse(roundPlayers, ActionType.Raise, line));
                }

                if (line.Contains("calls"))
                {
                    actions.Add(_actionBaseParser.Parse(roundPlayers, ActionType.Call, line));
                }

                if (line.Contains("collected"))
                {
                    actions.Add(_actionBaseParser.Parse(roundPlayers, ActionType.Collected, line));
                    break;
                }

                lineIndex++;

                if (RoundsBaseParser.IsRoundRow(lines[lineIndex]))
                    return actions;
            }

            return actions;
        }
    }
}