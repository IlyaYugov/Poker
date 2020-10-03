namespace Common.Updater
{
    public class BlindsMoneyUpdater
    {
        private readonly BlindMoneyUpdater _blindMoneyUpdater;

        public BlindsMoneyUpdater(BlindMoneyUpdater blindMoneyUpdater)
        {
            _blindMoneyUpdater = blindMoneyUpdater;
        }

        public void UpdateGameBankAndPlayersMoney(Game game, Player[] blindPlayers)
        {
            foreach (var blindPlayer in blindPlayers)
            {
                _blindMoneyUpdater.Update(game, blindPlayer);
            }
        }
    }
}