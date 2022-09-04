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
        private readonly IGrid _grid;

        public GridView(IGrid grid)
        {
            _grid = grid;
            _grid.PropertyChanged += _grid_PropertyChanged;
        }

        private void _grid_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(_grid.SetCell))
                return;

            Draw();
        }

        public void Draw()
        {
            Console.Clear();
            for (int i = 1; i < Grid.Size+1; i++)
            {
                var cell = _grid.GetCell(i - 1);
                char character = _characters[cell];
                Console.Write(character);
                if (i % NewLineMod == 0)
                    Console.Write('\n');
            }
        }
    }
}
