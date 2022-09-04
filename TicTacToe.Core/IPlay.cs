namespace TicTacToe.Core
{
    public interface IPlay
    {
        int Index { get; }
        IPlayer Player { get; }
    }
}
