using System.Collections.Generic;

namespace TicTacToe.Core.Board
{
    public interface IGrid
    {
        IEnumerable<Cell> GetCells();
        Cell GetCell(int index);
        void Reset();
        void SetCell(int index, Cell cell);
        bool IsCell(int index, Cell cell);
    }
}
