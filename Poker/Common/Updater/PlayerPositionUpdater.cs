using System;
using System.Collections.Generic;
using Common.Extenstions;

namespace Common.Updater
{
    public class PlayerPositionUpdater
    {
        public void Update(List<Player> players)
        {
            var bigBlindPlayerIndex = players.FindIndex(player => player.PositionType == PositionType.BigBlind);

            if (bigBlindPlayerIndex == -1)
            {
                return;
            }

            var index = bigBlindPlayerIndex;

            while (true)
            {
                var playerPositionType = players[index].PositionType;

                index++;

                if (index > players.Count - 1)
                    index = 0;

                if (players[index].PositionType == PositionType.Diller)
                    break;

                players[index].PositionType = playerPositionType.Next();
            }
        }
    }
}