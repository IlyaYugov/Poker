using System.Linq;

namespace Common.Combinations.CombinationsComparer
{
    public class MainCombinationsComparer : ICombinationsComparer
    {
        private readonly CombinationTypeGetter _combinationTypeGetter;

        public MainCombinationsComparer(CombinationTypeGetter combinationTypeGetter)
        {
            _combinationTypeGetter = combinationTypeGetter;
        }

        public CombinationCompareType Compare(PlayerGameSnapshot[] players, Board board)
        {
            var playersWithBoard = players.Select(s => new
            {
                Player = s,
                AllCards = board.Cards.Union(s.Cards).ToArray()
            });

            var playersWithBoardAndCombinationType = playersWithBoard.Select(s => new
            {
                Player = s,
                AllCards = s.AllCards,
                CombinationType = _combinationTypeGetter.GetCombinationType(s.AllCards)
            }).ToArray();

            var combinationType = playersWithBoardAndCombinationType
                .Max(p => p.CombinationType);

            var allPlayersWithMaximumCombination = playersWithBoardAndCombinationType
                .Where(s => s.CombinationType == combinationType);

            if (allPlayersWithMaximumCombination.Count() == 1)
                return CombinationCompareType.FirstWin;

            return CombinationCompareType.Tie;
        }
    }
}