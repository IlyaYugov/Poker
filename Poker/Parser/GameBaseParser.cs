using System.Collections.Generic;
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

        private Dictionary<string, Player> _parsedPlayers = new Dictionary<string, Player>();

        public GameBaseParser(GameInfoBaseParser gameInfoBaseParser, PlayersBaseParser playersBaseParser,
            RoundsBaseParser roundsBaseParser, PlayerBlindsBaseParser playerBlindsBaseParser,
            PlayerPositionUpdater playerPositionUpdater)
        {
            _gameInfoBaseParser = gameInfoBaseParser;
            _playersBaseParser = playersBaseParser;
            _roundsBaseParser = roundsBaseParser;
            _playerBlindsBaseParser = playerBlindsBaseParser;
        }

        public Game Parse(string[] lines, ref int lineIndex)
        {
            var game = _gameInfoBaseParser.Parse(lines, ref lineIndex);

            if (lineIndex >= lines.Length - 1)
                return null;

            game.PlayerGameSnapshots = _playersBaseParser.Parse(lines, ref lineIndex, game.PlayersCount);
            UpdatePlayersOnParsedEarly(game.PlayerGameSnapshots);

            game.Players = game.PlayerGameSnapshots.Select(ps => ps.Player).ToList();

            var blindPlayers = _playerBlindsBaseParser.Parse(game, lines, ref lineIndex);

            if (blindPlayers.Count != 2)
                return null;

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

        private void UpdatePlayersOnParsedEarly(List<PlayerGameSnapshot> playerGameSnapshots)
        {
            foreach (var playerGameSnapshot in playerGameSnapshots)
            {
                if (_parsedPlayers.TryGetValue(playerGameSnapshot.Player.NickName, out var existingPlayer))
                    playerGameSnapshot.Player = existingPlayer;
                else
                    _parsedPlayers.Add(playerGameSnapshot.Player.NickName, playerGameSnapshot.Player);
            }
        }
    }
}