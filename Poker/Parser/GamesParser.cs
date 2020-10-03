using System.Collections.Generic;
using Common;

namespace Parser
{
    public class GamesParser
    {
        private readonly GameBaseParser _gameBaseParser;
        public GamesParser(GameBaseParser gameBaseParser)
        {
            _gameBaseParser = gameBaseParser;
        }
        public List<Game> Parse(string[] lines)
        {
            var games = new List<Game>();
            int lineIndex = 0;

            while (lineIndex < lines.Length - 1)
            {
                var game = _gameBaseParser.Parse(lines, ref lineIndex);
                games.Add(game);
            }

            return games;
        }
    }
}