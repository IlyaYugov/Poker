namespace Common
{
    public class Card
    {
        public int Id { get; set; }
        public CardRank CardRank { get; }
        public CardSuit CardSuit { get; }

        public Card(CardRank cardRank, CardSuit cardSuit)
        {
            CardRank = cardRank;
            CardSuit = cardSuit;
        }

        public Card()
        {

        }
    }
}