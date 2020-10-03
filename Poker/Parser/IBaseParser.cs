namespace Parser
{
    public interface IBaseParser<TItem>
    {
        TItem Parse(string[] lines, ref int lineIndex);
    }
}
