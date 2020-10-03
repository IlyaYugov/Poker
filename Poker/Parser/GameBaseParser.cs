using System.Linq;
using Common;
using Common.Updater;

namespace Parser
{
    public class GameBaseParser : IBaseParser<Game>
    {
        private readonly GameInfoBaseParser _gameInfoBaseParser;
        private readonly PlayersBaseParser _playersBaseParser;
        private readonly RoundsBaseParser _roundsBaseParser;
        private readonly PlayerBlindsBaseParser _playerBlindsBaseParser;

        public GameBaseParser(GameInfoBaseParser gameInfoBaseParser, PlayersBaseParser playersBaseParser, RoundsBaseParser roundsBaseParser, PlayerBlindsBaseParser playerBlindsBaseParser, PlayerPositionUpdater playerPositionUpdater)
        {
            _gameInfoBaseParser = gameInfoBaseParser;
            _playersBaseParser = playersBaseParser;
            _roundsBaseParser = roundsBaseParser;
            _playerBlindsBaseParser = playerBlindsBaseParser;
        }

        public Game Parse(string[] lines, ref int lineIndex)
        {
            var game = _gameInfoBaseParser.Parse(lines, ref lineIndex);
            game.Players = _playersBaseParser.Parse(lines, ref lineIndex, game.PlayersCount);
            _playerBlindsBaseParser.Parse(game, lines, ref lineIndex);
            game.Rounds = _roundsBaseParser.Parse(game, lines, ref lineIndex);

            var cards = game.Rounds.SelectMany(r => r.Cards).ToList();

            if (cards.Any())
            {
                game.Board = new Board
                {
                    Cards = cards
                };
            }

            return game;
        }
    }
}