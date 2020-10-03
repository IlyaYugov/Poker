

using System.Collections.Generic;

namespace Common
{
    public class Player
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public double Money { get; set; }
        public List<Card> Cards { get; set; }
        public PositionType PositionType { get; set; }
        public IReadOnlyCollection<Round> StartedRounds { get; set; }
        public IReadOnlyCollection<Round> FinishedRounds { get; set; }
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
