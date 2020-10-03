using System.Collections.Generic;

namespace Common
{
    public class Game
    {
        public Game()
        {
            Rounds = new List<Round>();
        }

        public Player[] Players { get; set; }
        public Board Board { get; set; }
        public List<Round> Rounds { get; set; }
        public double TotalBank { get; set; }
        public string GameLimit  { get; set; }

        public double SmallBlind { get; set; }
        public double BigBlind { get; set; }
        public GameType GameType { get; set; }
        public int MaxPlayersCount { get; set; }
        public int PlayersCount { get; set; }
        public string ButtonSeatStringPart { get; set; }
    }
}