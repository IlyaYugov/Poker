using System;
using Common;
using Common.Updater;

namespace Parser
{
    public class RoundParser
    {
        private readonly PlayerActionsBaseParser _actionsBaseParser;
        private readonly ActionsUpdater _actionsUpdater;
        private readonly CardsBaseParser _cardsBaseParser;

        public RoundParser(PlayerActionsBaseParser actionsBaseParser, ActionsUpdater actionsUpdater, CardsBaseParser cardsBaseParser)
        {
            _actionsBaseParser = actionsBaseParser;
            _actionsUpdater = actionsUpdater;
            _cardsBaseParser = cardsBaseParser;
        }

        public Round Parse(Game game, Player[] startedPlayers, RoundType roundType, string[] lines, ref int lineIndex)
        {
            var round = Initialize(startedPlayers, roundType);
            round.Cards = _cardsBaseParser.Parse(lines[lineIndex]).ToArray();
            round.PlayerActions = _actionsBaseParser.Parse(startedPlayers, lines, ref lineIndex);

            _actionsUpdater.Update(game, round);

            return round;
        }

        private Round Initialize(Player[] startedPlayers, RoundType roundType)
        {
            var round = new Round
            {
                StartedPlayers = startedPlayers,
                RoundType = roundType,
                FinishedPlayers = new Player[startedPlayers.Length]
            };
            Array.Copy(startedPlayers, round.FinishedPlayers, round.StartedPlayers.Length);

            return round;
        }
    }
}