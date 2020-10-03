using System.Collections.Generic;
using System.Linq;
using Common;
using Common.Updater;

namespace Parser
{
    public class PlayerBlindsBaseParser
    {
        private readonly PlayerPositionUpdater _playerPositionUpdater;
        private readonly BlindsMoneyUpdater _blindsMoneyUpdater;

        public PlayerBlindsBaseParser(PlayerPositionUpdater playerPositionUpdater, BlindsMoneyUpdater blindsMoneyUpdater)
        {
            _playerPositionUpdater = playerPositionUpdater;
            _blindsMoneyUpdater = blindsMoneyUpdater;
        }

        public List<Player> Parse(Game game, string[] lines, ref int lineIndex)
        {
            var blindPlayers = new List<Player>();

            while (true)
            {
                if (lineIndex > lines.Length - 1)
                    return blindPlayers;

                var line = lines[lineIndex];
                if (line.Contains("small blind"))
                {
                    var smallBlindPlayer = game.Players.FirstOrDefault(p => line.Contains(p.NickName));

                    if (smallBlindPlayer == null)
                        return blindPlayers;

                    smallBlindPlayer.PositionType = PositionType.SmallBlind;
                    blindPlayers.Add(smallBlindPlayer);
                }

                if (line.Contains("big blind"))
                {
                    var bigBlindPlayer = game.Players.FirstOrDefault(p => line.Contains(p.NickName));

                    if (bigBlindPlayer == null)
                        return blindPlayers;

                    bigBlindPlayer.PositionType = PositionType.BigBlind;
                    blindPlayers.Add(bigBlindPlayer);

                    break;
                }

                lineIndex++;
            }

            _blindsMoneyUpdater.UpdateGameBankAndPlayersMoney(game, blindPlayers);
            _playerPositionUpdater.Update(game.Players);

            return blindPlayers;
        }
    }
}