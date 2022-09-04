using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace TicTacToe.Core.Board
{
    public class Grid : IGrid
    {
        public static readonly int Size = 9;
        private Cell[] Cells { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

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
            OnPropertyChanged();
        }

        public IEnumerable<Cell> GetCells()
        {
            return Cells;
        }

        public bool IsCell(int index, Cell cell)
        {
            return Cells[index] == cell;
        }

        void OnPropertyChanged([CallerMemberName] string name = null)
        {
            System.Console.WriteLine("OnPropertyChanged " + name);
            var handler = PropertyChanged;
            if (handler != null)
                handler.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
