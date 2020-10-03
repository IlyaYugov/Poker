using Common;

namespace Parser
{
    public class CardBaseParser
    {
        public virtual Card Parse(string cardString)
        {
            var rank = GetRankByChar(cardString[0]);
            var suit = GetSuitByChar(cardString[1]);
            var card = new Card(rank, suit);

            return card;
        }

        internal virtual CardSuit GetSuitByChar(char suit)
        {
            switch (suit)
            {
                case 'c':
                    return CardSuit.Club;
                case 'd':
                    return CardSuit.Diamond;
                case 'h':
                    return CardSuit.Heart;
                default:
                    return CardSuit.Spade;
            }
        }

        internal virtual CardRank GetRankByChar(char rank)
        {
            switch (rank)
            {
                case { } when (int)char.GetNumericValue(rank) != -1:
                    return (CardRank)(int)char.GetNumericValue(rank);
                case 'T':
                    return CardRank.Ten;
                case 'J':
                    return CardRank.Jack;
                case 'Q':
                    return CardRank.Queen;
                case 'K':
                    return CardRank.King;
                default:
                    return CardRank.Ace;
            }
        }
    }
}