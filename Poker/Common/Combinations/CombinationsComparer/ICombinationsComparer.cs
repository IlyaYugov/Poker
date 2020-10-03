namespace Common.Combinations.CombinationsComparer
{
    public interface ICombinationsComparer
    {
        CombinationCompareType Compare(Player[] players, Board board);
    }
}