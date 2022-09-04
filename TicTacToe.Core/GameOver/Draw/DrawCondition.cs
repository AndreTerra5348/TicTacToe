using TicTacToe.Core.Board;

namespace TicTacToe.Core.GameOver.Draw
{
    public class DrawCondition : IDrawCondition
    {
        public bool Draw(IGrid grid)
        {
            foreach (var cell in grid.GetCells())
            {
                if (cell == Cell.Empty)
                    return false;
            }
            return true;
        }
    }
}
