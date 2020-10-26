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

        public List<PlayerGameSnapshot> Parse(Game game, string[] lines, ref int lineIndex)
        {
            var blindPlayers = new List<PlayerGameSnapshot>();

            while (true)
            {
                if (lineIndex > lines.Length - 1)
                    return blindPlayers;

                var line = lines[lineIndex];
                if (line.Contains("small blind"))
                {
                    var smallBlindPlayer = game.PlayerGameSnapshots.FirstOrDefault(p => line.Contains(p.Player.NickName));

                    if (smallBlindPlayer == null)
                        return blindPlayers;

                    smallBlindPlayer.PositionType = PositionType.SmallBlind;
                    blindPlayers.Add(smallBlindPlayer);
                }

                if (line.Contains("big blind"))
                {
                    var bigBlindPlayer = game.PlayerGameSnapshots.FirstOrDefault(p => line.Contains(p.Player.NickName));

                    if (bigBlindPlayer == null)
                        return blindPlayers;

                    bigBlindPlayer.PositionType = PositionType.BigBlind;
                    blindPlayers.Add(bigBlindPlayer);

                    break;
                }

                lineIndex++;
            }

            _blindsMoneyUpdater.UpdateGameBankAndPlayersMoney(game, blindPlayers);
            _playerPositionUpdater.Update(game.PlayerGameSnapshots);

            return blindPlayers;
        }
    }
}