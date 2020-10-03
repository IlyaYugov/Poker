using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Common;
using Common.Extenstions;
using Common.Updater;
using Parser;

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

            var games = new List<Game>();

            var currentGame = new Game();
            var currentRound = new Round();
            var playerIndex = 0;



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

            var game = gamesParser.Parse(allFileLines);

            /*            foreach (var line in allFileLines)
                        {
                            if (line.Contains("#Game No"))
                            {
                                currentGame = new Game();
                                currentRound = new Round();
                                currentGame.Rounds.Add(currentRound);
                                games.Add(currentGame);
                                playerIndex = 0;
                            }

                            ParseGameInfo(currentGame, currentRound, line);
                            PlayersParser(currentGame, ref playerIndex, line);
                            ParseBlinds(currentGame, line); // ?????????????
                            ParseCards(currentGame, line);
                            ParseActions(currentGame, currentRound, line);
                            ParseRounds(currentGame, currentRound, line);
                        }*/
        }

        private static void ParseCards(Game currentGame, string line)
        {
            if (line.Contains("Dealt") || line.Contains("shows"))
            {
                var player = currentGame.Players.First(p => line.Contains(p.NickName));
                player.Cards = ParsePlayerAndBoardCards(line).ToArray();
            }
        }

        private static void ParseBlinds(Game currentGame, string line)
        {
            if (line.Contains("small blind"))
            {
                var smallBlindPlayer = currentGame.Players.First(p => line.Contains(p.NickName));
                smallBlindPlayer.Money -= currentGame.SmallBlind;
                smallBlindPlayer.PositionType = PositionType.SmallBlind;
                currentGame.TotalBank += currentGame.SmallBlind;
            }

            if (line.Contains("big blind"))
            {
                var bigBlindPlayer = currentGame.Players.First(p => line.Contains(p.NickName));
                bigBlindPlayer.Money -= currentGame.BigBlind;
                bigBlindPlayer.PositionType = PositionType.BigBlind;
                currentGame.TotalBank += currentGame.BigBlind;

                var index = Array.IndexOf(currentGame.Players, bigBlindPlayer);

                while (true)
                {
                    var currentPlayerPositionTYpe = currentGame.Players[index].PositionType;

                    index++;

                    if (index > currentGame.Players.Length - 1)
                        index = 0;

                    if (currentGame.Players[index].PositionType == PositionType.Diller)
                        break;

                    currentGame.Players[index].PositionType = currentPlayerPositionTYpe.Next();
                }
            }
        }

        private static void ParseGameInfo(Game currentGame, Round currentRound, string line)
        {
            if (line.Contains("888poker Snap"))
                currentGame.GameType = GameType.Cash;

            if (currentGame.Rounds.Any()
                && currentRound.RoundType == RoundType.None
                && line.Contains("No Limit Holdem"))
            {
                currentGame.GameLimit = line.Substring(0, line.LastIndexOf('$') + 1);
                currentGame.SmallBlind = Convert.ToDouble(line.Substring(0, line.IndexOf('$') - 1));
                currentGame.BigBlind = Convert.ToDouble(line.Substring(line.IndexOf('/') + 1, (line.LastIndexOf('$') - 2) - (line.IndexOf('/') + 1) + 1));
            }


            if (line.Contains("Table Quilpue"))
                currentGame.MaxPlayersCount = Convert.ToInt32(line.Replace("Table Quilpue ", "").Substring(0, 1));

            if (line.Contains("button"))
                currentGame.ButtonSeatStringPart = line.Substring(0, 6);

            if (line.Contains("Total number of players"))
            {
                currentGame.PlayersCount = Convert.ToInt32(line.Substring(line.Length - 1, 1));
                currentGame.Players = new Player[currentGame.PlayersCount];
            }
        }

        private static void PlayersParser(Game currentGame, ref int playerIndex, string line)
        {
            if (line.Contains("Seat") && line.Contains(":"))
            {
                currentGame.Players[playerIndex] = ParsePlayer(line);

                if (line.Contains(currentGame.ButtonSeatStringPart))
                    currentGame.Players[playerIndex].PositionType = PositionType.Diller;

                playerIndex++;
            }
        }

        private static void ParseActions(Game currentGame, Round currentRound, string line)
        {
            if (line.Contains("folds"))
            {
                ParseAndSavePlayersActions(currentGame, currentRound, ActionType.Fold, line);
            }

            if (line.Contains("checks"))
            {
                ParseAndSavePlayersActions(currentGame, currentRound, ActionType.Check, line);
            }

            if (line.Contains("raises") || line.Contains("bets"))
            {
                ParseAndSavePlayersActions(currentGame, currentRound, ActionType.Raise, line);
            }

            if (line.Contains("calls"))
            {
                ParseAndSavePlayersActions(currentGame, currentRound, ActionType.Call, line);
            }

            if (line.Contains("collected"))
            {
                ParseAndSavePlayersActions(currentGame, currentRound, ActionType.Collected, line);
            }
        }

        private static void ParseRounds(Game currentGame, Round currentRound, string line)
        {
            if (line.Contains("down cards"))
            {
                ParseRound(currentGame, currentRound, RoundType.PreFlop, line);
            }

            if (line.Contains("flop"))
            {
                ParseRound(currentGame, currentRound, RoundType.Flop, line);
            }

            if (line.Contains("turn"))
            {
                ParseRound(currentGame, currentRound, RoundType.Turn, line);
            }

            if (line.Contains("river"))
            {
                ParseRound(currentGame, currentRound, RoundType.River, line);
            }

            if (line.Contains("Summary"))
            {
                ParseRound(currentGame, currentRound, RoundType.ShowDown, line);
            }
        }

        private static void ParseAndSavePlayersActions(Game game, Round round, ActionType actionType, string line)
        {
            var player = round.FinishedPlayers.First(p => line.Contains(p.NickName));
            var action = new PlayerAction
            {
                Player = player,
                ActionType = actionType,
                Money = ParseMoney(line, '[')
            };

            if (actionType == ActionType.Fold)
            {
                round.FinishedPlayers = round.FinishedPlayers.Where(p => p != player).ToArray();
            }

            round.PlayerActions.Add(action);
            if (actionType != ActionType.Collected && actionType != ActionType.Check)
            {
                player.Money -= action.Money;
                game.TotalBank += action.Money;
            }
            if (actionType == ActionType.Collected)
            {
                player.Money += action.Money;
            }
        }

        private static void ParseRound(Game game, Round round, RoundType roundType, string line)
        {
            if (game.Board == null)
                game.Board = new Board();

            if (game.Board.Cards == null)
                game.Board.Cards = new List<Card>();

            if (roundType == RoundType.PreFlop)
            {
                round.StartedPlayers = game.Players;
                round.FinishedPlayers = new Player[game.Players.Length];
                round.RoundType = roundType;
                Array.Copy(game.Players, round.FinishedPlayers, game.Players.Length);
            }
            else
            {
                round = new Round
                {
                    StartedPlayers = round.FinishedPlayers,
                    RoundType = roundType,
                    FinishedPlayers = new Player[round.StartedPlayers.Length]
                };
                Array.Copy(round.StartedPlayers, round.FinishedPlayers, round.StartedPlayers.Length);
                game.Board.Cards.AddRange(ParsePlayerAndBoardCards(line));
                game.Rounds.Add(round);
            }
        }

        private static Player ParsePlayer(string line)
        {
            var separator = '(';
            var startNickNameIndex = line.IndexOf(':') + 2;
            var finishNickNameIndex = line.IndexOf(separator) - 2;

            var player = new Player
            {
                NickName = line.Substring(startNickNameIndex, finishNickNameIndex - startNickNameIndex + 1),
                Money = ParseMoney(line, separator)
            };

            return player;
        }

        private static List<Card> ParsePlayerAndBoardCards(string line)
        {
            if (!line.Contains('['))
                return new List<Card>();

            var startNickNameIndex = line.IndexOf('[') + 2;
            var finishNickNameIndex = line.IndexOf(']') - 2;

            var cardsString = line.Substring(startNickNameIndex, finishNickNameIndex - startNickNameIndex + 1);
            var cards = cardsString.Split(", ").Select(ParseCard).ToList();

            return cards;
        }

        private static Card ParseCard(string cardString)
        {
            var rank = GetRankByChar(cardString[0]);
            var suit = GetSuitByChar(cardString[1]);
            var card = new Card(rank, suit);

            return card;
        }

        private static CardSuit GetSuitByChar(char suit)
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

        private static CardRank GetRankByChar(char rank)
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

        public static double ParseMoney(string line, char separator)
        {
            if (!line.Contains(separator))
                return 0;

            var separatorIndex = line.IndexOf(separator);
            var subLine = line.Substring(separatorIndex, line.Length - separatorIndex);

            var firstIndexOfNumber = subLine.ToList().FindIndex(char.IsNumber);
            var lastIndexOfNumber = subLine.ToList().FindLastIndex(char.IsNumber);

            var money = Convert.ToDouble(subLine.Substring(firstIndexOfNumber, lastIndexOfNumber - firstIndexOfNumber + 1));

            return money;
        }
    }
}
