namespace Common.Updater
{
    public class BlindMoneyUpdater
    {
        private void UpdateGameBank(Game game, PlayerGameSnapshot playerGameSnapshot)
        {
            if (playerGameSnapshot.PositionType == PositionType.SmallBlind)
            {
                game.TotalBank += game.SmallBlind;
            }

            if (playerGameSnapshot.PositionType == PositionType.BigBlind)
            {
                game.TotalBank += game.BigBlind;
            }
        }

        private void UpdatePlayerMoney(Game game, PlayerGameSnapshot playerGameSnapshot)
        {
            if (playerGameSnapshot.PositionType == PositionType.SmallBlind)
            {
                playerGameSnapshot.GaveMoneyToBank += game.SmallBlind;
            }

            if (playerGameSnapshot.PositionType == PositionType.BigBlind)
            {
                playerGameSnapshot.GaveMoneyToBank += game.BigBlind;
            }
        }

        public void Update(Game game, PlayerGameSnapshot playerGameSnapshot)
        {
            UpdatePlayerMoney(game, playerGameSnapshot);
            UpdateGameBank(game, playerGameSnapshot);
        }
    }
}