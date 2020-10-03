using System.Linq;

namespace Common.Updater
{
    public class ActionUpdater
    {
        private void UpdateRoundPlayers(Round round, Player player, PlayerAction action)
        {
            if (action.ActionType == ActionType.Fold)
            {
                round.FinishedPlayers = round.FinishedPlayers.Where(p => p != player).ToList();
            }
        }

        private void UpdateGameTotalBank(Game game, PlayerAction action)
        {
            if (action.ActionType != ActionType.Collected)
            {
                game.TotalBank += action.Money;
            }
        }

        private void UpdatePlayerMoney(Player player, PlayerAction action)
        {
            if(player == null)
                return;
            if (action.ActionType == ActionType.Collected)
            {
                player.Money += action.Money;
            }
            else
            {
                player.Money -= action.Money;
            }
        }

        public void Update(Game game, Round round, PlayerAction action)
        {
            UpdateGameTotalBank(game,action);
            UpdatePlayerMoney(action.Player, action);
            UpdateRoundPlayers(round, action.Player, action);
        }
    }
}