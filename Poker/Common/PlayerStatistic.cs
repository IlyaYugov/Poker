namespace Common
{
    public class PlayerStatistic
    {
        public Player Player { get; set; }
        public int TotalGames { get; set; }
        public int TotalEnterFlop { get; set; }
        public int TotalEnterTurn { get; set; }
        public int TotalEnterRiver { get; set; }
        public int TotalEnterShowDown { get; set; }
        public double WinnedMoney { get; set; }
        public int WinnedBlinds { get; set; }
    }
}