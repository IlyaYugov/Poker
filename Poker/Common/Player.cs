

namespace Common
{
    public class Player
    {
        public string NickName { get; set; }
        public double Money { get; set; }
        public Card[] Cards { get; set; }
        public PositionType PositionType { get; set; }
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
