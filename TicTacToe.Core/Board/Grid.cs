using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.Core.Board
{

    public class Grid : IGrid
    {
        public static readonly int Size = 9;
        private readonly Cell[] _cells;

        public Grid()
        {
            _cells = Enumerable.Repeat(Cell.Empty, Size).ToArray();            
        }

        public void Reset()
        {
            for (int i = 0; i < Size; i++)
                _cells[i] = Cell.Empty;
        }

        public Cell GetCell(int index)
        {
            return _cells[index];
        }

        public void SetCell(int index, Cell cell)
        {
            _cells[index] = cell;
        }        

        public IEnumerable<Cell> GetCells()
        {
            return _cells;
        }

        public bool IsCell(int index, Cell cell)
        {
            return _cells[index] == cell;
        }
    }
}
