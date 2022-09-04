using TicTacToe.Core.Board;

namespace TicTacToe.Core.GameOver.Victory
{
    public interface IVictoryCondition
    {
        bool Won(IGrid board, IPlayer player);
    }
}
