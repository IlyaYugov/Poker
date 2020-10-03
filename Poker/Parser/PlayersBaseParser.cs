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

        public Player[] Parse(string[] lines, ref int lineIndex, int playersCount)
        {
            var players = new Player[playersCount];
            var playerIndex = 0;

            do
            {
                lineIndex++;
                var player = _playerBaseParser.Parse(lines[lineIndex]);
                players[playerIndex] = player;
                playerIndex++;
            } while (playerIndex < players.Length);

            return players;
        }
    }
}