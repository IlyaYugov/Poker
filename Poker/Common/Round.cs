using System.Collections.Generic;

namespace Common
{
    public class Round
    {
        public Round()
        {
            PlayerActions = new List<PlayerAction>();
        }
        public Player[] StartedPlayers { get; set; }
        public Player[] FinishedPlayers { get; set; }
        public RoundType RoundType { get; set; }
        public List<PlayerAction> PlayerActions { get; set; }
        public Card[] Cards { get; set; }

    }
}