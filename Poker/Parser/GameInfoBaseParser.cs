using System;
using System.Collections.Generic;
using Common;

namespace Parser
{
    public class GameInfoBaseParser : IBaseParser<Game>
    {
        public Game Parse(string[] lines, ref int lineIndex)
        {
            var currentGame = new Game();

            while (true)
            {
                if (lineIndex >= lines.Length - 1)
                    return currentGame;

                var line = lines[lineIndex];

/*                if (line.Contains("888poker Snap"))
                    currentGame.GameType = GameType.Cash;*/

                if (line.Contains("No Limit Holdem"))
                {
                    currentGame.GameLimit = line.Substring(0, line.LastIndexOf('$') + 1);
                    currentGame.SmallBlind = Convert.ToDouble(line.Substring(0, line.IndexOf('$') - 1));
                    currentGame.BigBlind = Convert.ToDouble(line.Substring(line.IndexOf('/') + 1,
                        (line.LastIndexOf('$') - 2) - (line.IndexOf('/') + 1) + 1));
                }


                if (line.Contains("Table Quilpue"))
                    currentGame.MaxPlayersCount = Convert.ToInt32(line.Replace("Table Quilpue ", "").Substring(0, 1));

                if (line.Contains("button"))
                    currentGame.ButtonSeatStringPart = line.Substring(0, 6);

                if (line.Contains("Total number of players"))
                {
                    currentGame.PlayersCount = Convert.ToInt32(line.Substring(line.Length - 1, 1));
                    currentGame.PlayerGameSnapshots = new List<PlayerGameSnapshot>(currentGame.PlayersCount);
                    break;
                }

                lineIndex++;
            }

            return currentGame;
        }
    }
}