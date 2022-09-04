using System.Collections.Generic;
using System.ComponentModel;

namespace TicTacToe.Core.Board
{
    public interface IGrid : INotifyPropertyChanged
    {
        IEnumerable<Cell> GetCells();
        Cell GetCell(int index);
        void Reset();
        void SetCell(int index, Cell cell);
        bool IsCell(int index, Cell cell);
    }
}
