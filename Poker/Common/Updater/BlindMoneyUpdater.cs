namespace Common.Updater
{
    public class BlindMoneyUpdater
    {
        private void UpdateGameBank(Game game, Player player)
        {
            if (player.PositionType == PositionType.SmallBlind)
            {
                game.TotalBank += game.SmallBlind;
            }

            if (player.PositionType == PositionType.BigBlind)
            {
                game.TotalBank += game.BigBlind;
            }
        }

        private void UpdatePlayerMoney(Game game, Player player)
        {
            if (player.PositionType == PositionType.SmallBlind)
            {
                player.Money -= game.SmallBlind;
            }

            if (player.PositionType == PositionType.BigBlind)
            {
                player.Money -= game.BigBlind;
            }
        }

        public void Update(Game game, Player player)
        {
            UpdatePlayerMoney(game, player);
            UpdateGameBank(game, player);
        }
    }
}