using System.Collections.Generic;
using System.Linq;
using Common;

namespace Parser
{
    public class RoundsBaseParser
    {
        private static readonly List<string> RoundPatterns = new List<string>
        { "down cards", "flop", "turn", "river", "Summary"};

        private readonly RoundParser _roundParser;

        public RoundsBaseParser(RoundParser roundParser)
        {
            _roundParser = roundParser;
        }

        public List<Round> Parse(Game game, string[] lines, ref int lineIndex)
        {
            var rounds = new List<Round>();

            while (true)
            {
                var line = lines[lineIndex];

                if (line.Contains("down cards"))
                {
                    rounds.Add(_roundParser.Parse(game, game.Players, RoundType.PreFlop, lines, ref lineIndex));
                }

                if (line.Contains("flop"))
                {
                    rounds.Add(_roundParser.Parse(game, rounds.Last().FinishedPlayers, RoundType.Flop, lines, ref lineIndex));
                }

                if (line.Contains("turn"))
                {
                    rounds.Add(_roundParser.Parse(game, rounds.Last().FinishedPlayers, RoundType.Turn, lines, ref lineIndex));
                }

                if (line.Contains("river"))
                {
                    rounds.Add(_roundParser.Parse(game, rounds.Last().FinishedPlayers, RoundType.River, lines, ref lineIndex));
                }

                if (line.Contains("Summary"))
                {
                    rounds.Add(_roundParser.Parse(game, rounds.Last().FinishedPlayers, RoundType.ShowDown, lines, ref lineIndex));
                    break;
                }

                if (!IsRoundRow(line))
                    lineIndex++;
            }

            return rounds;
        }

        public static bool IsRoundRow(string line)
        {
            foreach (var pattern in RoundPatterns)
            {
                if (line.Contains(pattern))
                    return true;
            }

            return false;
        }
    }
}