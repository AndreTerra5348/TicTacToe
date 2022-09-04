using System;
using System.Collections.Generic;
using System.ComponentModel;
using TicTacToe.Core.Board;

namespace TicTacToe.Terminal.Views
{
    class GridView : IGridView
    {
        private readonly Dictionary<Cell, char> _characters = new Dictionary<Cell, char>()
        {
            { Cell.Empty, '_' },
            { Cell.P1, 'O' },
            { Cell.P2, 'X' }
        };
        private readonly int NewLineMod = 3;
        private readonly char[] _cells;

        public GridView()
        {
            _cells = new char[]
            {
                _characters[Cell.Empty], _characters[Cell.Empty], _characters[Cell.Empty],
                _characters[Cell.Empty], _characters[Cell.Empty], _characters[Cell.Empty],
                _characters[Cell.Empty], _characters[Cell.Empty], _characters[Cell.Empty]
            };
        }

        public void SetCell(int index, Cell cell)
        {
            _cells[index] = _characters[cell];
            Show();
        }

        public void Reset()
        {
            for(int i = 0; i < _cells.Length; i++)
            {
                _cells[i] = _characters[Cell.Empty];
            }

            Show();
        }

        private void Show()
        {
            Console.Clear();
            for (int i = 1; i < _cells.Length + 1; i++)
            {
                Console.Write(_cells[i - 1]);
                if (i % NewLineMod == 0)
                    Console.Write('\n');
            }
        }
    }
}
