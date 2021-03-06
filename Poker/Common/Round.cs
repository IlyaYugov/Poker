﻿using System.Collections.Generic;

namespace Common
{
    public class Round
    {
        public Round()
        {
            PlayerActions = new List<PlayerAction>();
        }

        public int Id { get; set; }
        public List<PlayerGameSnapshot> StartedPlayers { get; set; }
        public List<PlayerGameSnapshot> FinishedPlayers { get; set; }
        public RoundType RoundType { get; set; }
        public List<PlayerAction> PlayerActions { get; set; }
        public List<Card> Cards { get; set; }
        public Game Game { get; set; }
    }
}