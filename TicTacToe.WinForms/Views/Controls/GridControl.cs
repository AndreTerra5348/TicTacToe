using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TicTacToe.Core.Board;

namespace TicTacToe.WinForms.Views.Controls
{
    public partial class GridControl : UserControl
    {
        private readonly Dictionary<Cell, string> _characters = new Dictionary<Cell, string>()
        {
            { Cell.Empty, String.Empty },
            { Cell.P1, "O" },
            { Cell.P2, "X" }
        };
        private readonly Button[] _buttons;

        public EventHandler<int> ButtonClick;

        public GridControl()
        {
            InitializeComponent();
            _buttons = new Button[]
            {
                button1,
                button2,
                button3,
                button4,
                button5,
                button6,
                button7,
                button8,
                button9
            };
            
            for(int i = 0; i < _buttons.Length; i++)
            {
                _buttons[i].Tag = i;
                _buttons[i].Click += Cell_Click;
            }
        }

        private void Cell_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            OnButtonClicked(Convert.ToInt32(button.Tag));
        }

        private void OnButtonClicked(int index)
        {
            var handler = ButtonClick;
            if (handler != null)
                handler.Invoke(this, index);
            _buttons[index].Enabled = false;
        }

        public void Reset()
        {
            foreach(var button in _buttons)
            {
                button.Enabled = true;
                button.Text = String.Empty;
            }
        }

        public void SetCell(int index, Cell cell)
        {
            Console.WriteLine("Set Cell");
            _buttons[index].Text = _characters[cell];
        }

    }
}
