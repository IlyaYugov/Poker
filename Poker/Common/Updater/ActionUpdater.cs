using System.Linq;

namespace Common.Updater
{
    public class ActionUpdater
    {
        private void UpdateRoundPlayers(Round round, PlayerGameSnapshot playerGameSnapshot, PlayerAction action)
        {
            if (action.ActionType == ActionType.Fold)
            {
                round.FinishedPlayers = round.FinishedPlayers.Where(p => p != playerGameSnapshot).ToList();
            }
        }

        private void UpdateGameTotalBank(Game game, PlayerAction action)
        {
            if (action.ActionType != ActionType.Collected)
            {
                game.TotalBank += action.Money;
            }
        }

        private void UpdatePlayerMoney(PlayerGameSnapshot playerGameSnapshot, PlayerAction action)
        {
            if(playerGameSnapshot == null)
                return;
            if (action.ActionType == ActionType.Collected)
            {
                playerGameSnapshot.CollectedMoney += action.Money;
            }
            else
            {
                playerGameSnapshot.GaveMoneyToBank += action.Money;
            }
        }

        public void Update(Game game, Round round, PlayerAction action)
        {
            UpdateGameTotalBank(game,action);
            UpdatePlayerMoney(action.PlayerGameSnapshot, action);
            UpdateRoundPlayers(round, action.PlayerGameSnapshot, action);
        }
    }
}