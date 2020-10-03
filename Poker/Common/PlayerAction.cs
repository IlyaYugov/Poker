namespace Common
{
    public class PlayerAction
    {
        public int Id { get; set; }
        public Player Player { get; set; }
        public ActionType ActionType { get; set; }
        public double Money { get; set; }
    }
}