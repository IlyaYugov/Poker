namespace Common
{
    public class PlayerAction
    {
        public int Id { get; set; }
        public PlayerGameSnapshot PlayerGameSnapshot { get; set; }
        public ActionType ActionType { get; set; }
        public double Money { get; set; }
    }
}