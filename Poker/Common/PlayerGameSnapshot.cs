

using System.Collections.Generic;

namespace Common
{
    public class PlayerGameSnapshot
    {
        public int Id { get; set; }
        public double MoneyOnStart { get; set; }
        public double CollectedMoney { get; set; }
        public double GaveMoneyToBank { get; set; }
        public List<Card> Cards { get; set; }
        public PositionType PositionType { get; set; }
        public IReadOnlyCollection<Round> StartedRounds { get; set; }
        public IReadOnlyCollection<Round> FinishedRounds { get; set; }
        public Player Player { get; set; }
        public Game Game { get; set; }
    }

    public enum PositionType
    {
        None,
        SmallBlind,
        BigBlind,
        UnderTheGun,
        MidlePosition,
        CottOff,
        Diller
    }
}
