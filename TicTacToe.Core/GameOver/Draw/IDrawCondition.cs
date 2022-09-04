using TicTacToe.Core.Board;

namespace TicTacToe.Core.GameOver.Draw
{
    public interface IDrawCondition
    {
        bool Draw(IGrid grid);
    }
}
