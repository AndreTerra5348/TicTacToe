namespace TicTacToe.Core.Board.Rules
{
    public interface IGridRule
    {
        bool IsPlayAllowed(IPlay play);
    }
}
