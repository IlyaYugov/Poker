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

                if (line.Contains("down cards") && IsContainsString2(line))
                {
                    rounds.Add(_roundParser.Parse(game, game.Players, RoundType.PreFlop, lines, ref lineIndex));
                }

                if (line.Contains("flop") && IsContainsString2(line))
                {
                    rounds.Add(_roundParser.Parse(game, rounds.Last().FinishedPlayers, RoundType.Flop, lines, ref lineIndex));
                }

                if (line.Contains("turn") && IsContainsString2(line))
                {
                    rounds.Add(_roundParser.Parse(game, rounds.Last().FinishedPlayers, RoundType.Turn, lines, ref lineIndex));
                }

                if (line.Contains("river") && IsContainsString2(line))
                {
                    rounds.Add(_roundParser.Parse(game, rounds.Last().FinishedPlayers, RoundType.River, lines, ref lineIndex));
                }

                if (line.Contains("Summary") && IsContainsString2(line))
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
                if (line.Contains(pattern) && IsContainsString2(line))
                    return true;
            }

            return false;
        }

        private static bool IsContainsString2(string line)
        {
            return line.Contains("**");
        }
    }
}