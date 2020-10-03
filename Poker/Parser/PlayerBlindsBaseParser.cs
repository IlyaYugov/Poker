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

        public Player[] Parse(Game game, string[] lines, ref int lineIndex)
        {
            var blindPlayers = new Player[2];

            while (true)
            {
                var line = lines[lineIndex];
                if (line.Contains("small blind"))
                {
                    var smallBlindPlayer = game.Players.First(p => line.Contains(p.NickName));
                    smallBlindPlayer.PositionType = PositionType.SmallBlind;
                    blindPlayers[0] = smallBlindPlayer;
                }

                if (line.Contains("big blind"))
                {
                    var bigBlindPlayer = game.Players.First(p => line.Contains(p.NickName));
                    bigBlindPlayer.PositionType = PositionType.BigBlind;
                    blindPlayers[1] = bigBlindPlayer;

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