using System.Collections.Generic;
using Common;

namespace Parser
{
    public class PlayersBaseParser
    {
        private readonly PlayerBaseParser _playerBaseParser;

        public PlayersBaseParser(PlayerBaseParser playerBaseParser)
        {
            _playerBaseParser = playerBaseParser;
        }

        public List<Player> Parse(string[] lines, ref int lineIndex, int playersCount)
        {
            var players = new List<Player>(playersCount);
            var playerIndex = 0;

            do
            {
                lineIndex++;
                var player = _playerBaseParser.Parse(lines[lineIndex]);
                players.Add(player);
                playerIndex++;
            } while (playerIndex < playersCount);

            return players;
        }
    }
}