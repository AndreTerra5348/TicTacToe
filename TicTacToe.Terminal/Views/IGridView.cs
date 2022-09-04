using TicTacToe.Core.Board;

namespace TicTacToe.Terminal.Views
{
    interface IGridView
    {
        void SetCell(int index, Cell cell);
        void Reset();
    }
}
