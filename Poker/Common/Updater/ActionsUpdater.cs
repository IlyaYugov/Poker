namespace Common.Updater
{
    public class ActionsUpdater
    {
        private readonly ActionUpdater _actionUpdater;

        public ActionsUpdater(ActionUpdater actionUpdater)
        {
            _actionUpdater = actionUpdater;
        }

        public void Update(Game game, Round round)
        {
            foreach (var action in round.PlayerActions)
            {
                _actionUpdater.Update(game, round, action);
            }
        }
    }
}