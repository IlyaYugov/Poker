using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Common;
using Common.Extenstions;
using Common.Updater;
using Parser;
using PosgreSqlPovider;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstPlayerCards = new[]
            {
                new Card(CardRank.Ace, CardSuit.Diamond),
                new Card(CardRank.Two, CardSuit.Diamond),
            };
            var secondPlayerCards = new[]
            {
                new Card(CardRank.Ace, CardSuit.Diamond),
                new Card(CardRank.Two, CardSuit.Diamond),
            };
            var boardCards = new[]
            {
                new Card(CardRank.Two, CardSuit.Heart),
                new Card(CardRank.Two, CardSuit.Club),
                new Card(CardRank.Three, CardSuit.Diamond),
                new Card(CardRank.Five, CardSuit.Diamond),
                new Card(CardRank.Four, CardSuit.Diamond),
            };

            var allCards = firstPlayerCards.Union(boardCards).ToArray();

            //var IsPair = CombinationFactory.IsPair(allCards);
            //var IsTwoPairs = CombinationFactory.IsTwoPairs(allCards);
            //var IsThreeOfAKind = CombinationFactory.IsThreeOfAKind(allCards);
            //var IsStraight = CombinationFactory.IsStraight(allCards);
            //var IsFlush = CombinationFactory.IsFlush(allCards);
            //var IsFullHouse = CombinationFactory.IsFullHouse(allCards);
            //var IsFourOfAKind = CombinationFactory.IsFourOfAKind(allCards);
            //var IsStraightFlush = CombinationFactory.IsStraightFlush(allCards);

            var two = @"(\d)?\1";
            var three = @"(\d)\1\1";
            var four = @"(\d)\1\1\1";

            var flush = @"\bs*(\d)\b";


            //string three = @"(\d)\1\1";
            var pairRegularExp = new Regex(two);

            var t1 = Regex.Matches("113444", two);
            var t2 = Regex.Matches("113444", two);
            var t3 = Regex.Matches("113444", two);
            var t4 = Regex.Matches("113444", two);

            var t5 = Regex.Matches("1122234444", three);
            var t6 = Regex.Matches("112234444", three);
            var t221 = Regex.Matches("112234444", three);
            var t231 = Regex.Matches("112234444", three);

            var t341 = Regex.Matches("111233345", four);
            var t351 = Regex.Matches("111233345", four);
            var t361 = Regex.Matches("1112333345", four);
            var t371 = Regex.Matches("11112333345", four);

            var t376 = Regex.Matches(" t0 s1 s2 s3 s4 s5 s6", flush);


            var allFileLines = File.ReadAllLines(@"C:\Projects\PokerStatistic\StaticticExample.txt");


            var gamesParser = new GamesParser(
                new GameBaseParser(
                    new GameInfoBaseParser(),
                    new PlayersBaseParser(
                        new PlayerBaseParser(
                            new MoneyBaseParser())),
                    new RoundsBaseParser(
                        new RoundParser(
                            new PlayerActionsBaseParser(
                                new PlayerActionBaseParser(
                                    new MoneyBaseParser())),
                            new ActionsUpdater(
                                new ActionUpdater()),
                            new CardsBaseParser(
                                new CardBaseParser()))),
                    new PlayerBlindsBaseParser(
                        new PlayerPositionUpdater(),
                        new BlindsMoneyUpdater(
                            new BlindMoneyUpdater())),
                    new PlayerPositionUpdater()));

            var filePaths = Directory
                .GetFiles(@"C:\Users\ilyaugov\Documents\888poker\HandHistory\Napaum");

            filePaths = filePaths.Where(f =>
                !f.Contains("Sit & Go") &&
                !f.Contains("Tournament") &&
                !f.Contains("BLAST")).ToArray();

            var games = new List<Game>();

            Debug.WriteLine($"Total count: {filePaths.Length}");
            int i = 0;

            foreach (var filePath in filePaths)
            {
                allFileLines = File.ReadAllLines(filePath);
                games.AddRange(gamesParser.Parse(allFileLines));

                Debug.WriteLine($"completed: {++i}");
            }

            /*var gamesFileStrings = filePaths.SelectMany(File.ReadAllLines).ToArray();
            var games = gamesParser.Parse(gamesFileStrings);*/

            var dbContext = new PokerDbContext();

            dbContext.Game.AddRange(games);
            dbContext.SaveChanges();
        }
    }
}
