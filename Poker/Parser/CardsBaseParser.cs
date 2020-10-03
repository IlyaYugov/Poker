using System.Collections.Generic;
using System.Linq;
using Common;

namespace Parser
{
    public class CardsBaseParser
    {
        private readonly CardBaseParser _cardBaseParser;

        public CardsBaseParser(CardBaseParser cardBaseParser)
        {
            _cardBaseParser = cardBaseParser;
        }

        public virtual List<Card> Parse(string line)
        {
            if (!line.Contains('['))
                return new List<Card>();

            var startNickNameIndex = line.IndexOf('[') + 2;
            var finishNickNameIndex = line.IndexOf(']') - 2;

            var cardsString = line.Substring(startNickNameIndex, finishNickNameIndex - startNickNameIndex + 1);
            var cards = cardsString.Split(", ").Select(_cardBaseParser.Parse).ToList();

            return cards;
        }
    }
}