namespace Common.Combinations.CombinationsComparer
{
    public interface ICombinationsComparer
    {
        CombinationCompareType Compare(PlayerGameSnapshot[] players, Board board);
    }
}