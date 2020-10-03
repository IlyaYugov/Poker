using System;
using Common.Extenstions;

namespace Common.Updater
{
    public class PlayerPositionUpdater
    {
        public void Update(Player[] players)
        {
            var bigBlindPlayerIndex = Array.FindIndex(players, 0, player => player.PositionType == PositionType.BigBlind);

            if (bigBlindPlayerIndex == -1)
            {
                return;
            }

            var index = bigBlindPlayerIndex;

            while (true)
            {
                var playerPositionType = players[index].PositionType;

                index++;

                if (index > players.Length - 1)
                    index = 0;

                if (players[index].PositionType == PositionType.Diller)
                    break;

                players[index].PositionType = playerPositionType.Next();
            }
        }
    }
}