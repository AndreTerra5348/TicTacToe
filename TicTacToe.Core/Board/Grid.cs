using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.Core.Board
{

    public class Grid : IGrid
    {
        public static readonly int Size = 9;
        private Cell[] Cells { get; set; }

        public Grid()
        {
            Cells = Enumerable.Repeat(Cell.Empty, Size).ToArray();            
        }

        public void Reset()
        {
            for (int i = 0; i < Size; i++)
                Cells[i] = Cell.Empty;
        }

        public Cell GetCell(int index)
        {
            return Cells[index];
        }

        public void SetCell(int index, Cell cell)
        {
            Cells[index] = cell;
        }        

        public IEnumerable<Cell> GetCells()
        {
            return Cells;
        }

        public bool IsCell(int index, Cell cell)
        {
            return Cells[index] == cell;
        }
    }
}
