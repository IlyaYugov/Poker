using Common;

namespace Parser
{
    public class PlayerBaseParser
    {
        private readonly MoneyBaseParser _moneyBaseParser;

        public PlayerBaseParser(MoneyBaseParser moneyBaseParser)
        {
            _moneyBaseParser = moneyBaseParser;
        }

        public PlayerGameSnapshot Parse(string line)
        {
            var startNickNameIndex = line.IndexOf(':') + 2;
            var finishNickNameIndex = line.IndexOf('(') - 2;

            var player = new PlayerGameSnapshot
            {
                Player = new Player
                {
                    NickName = line.Substring(startNickNameIndex, finishNickNameIndex - startNickNameIndex + 1)
                },
                MoneyOnStart = _moneyBaseParser.Parse(line,'(')
            };

            return player;
        }
    }
}