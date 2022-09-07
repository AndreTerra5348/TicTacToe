using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TicTacToe.Core;
using TicTacToe.Core.Board;
using TicTacToe.Core.GameOver;

namespace TicTacToe.WinForms.Views
{
    public partial class GameWindow : Form, IGameWindow
    {
        public event EventHandler<int> CellClick;
        public event EventHandler ResetClick;

        private readonly Button[] _buttons;

        private readonly Dictionary<Cell, string> _characters = new Dictionary<Cell, string>()
        {
            { Cell.Empty, String.Empty },
            { Cell.P1, "O" },
            { Cell.P2, "X" }
        };

        private readonly Dictionary<Outcome, string> _outcomeMessage = new Dictionary<Outcome, string>()
        {
            { Outcome.P1Victory, "Player 1 Won!" },
            { Outcome.P2Victory, "Player 2 Won!" },
            { Outcome.Draw, "Draw!" },
        };

        public GameWindow()
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
                button9,
            };

            for (int i = 0; i < _buttons.Length; i++)
            {
                _buttons[i].Tag = i;
                _buttons[i].Click += Button_Click;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var handler = CellClick;
            if (handler != null)
                handler.Invoke(this, Convert.ToInt32(button.Tag));
            button.Enabled = false;
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure?", "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            var handler = ResetClick;

            if (handler != null)
                handler.Invoke(this, EventArgs.Empty);

        }

        public void SetCell(int index, Cell cell)
        {
            _buttons[index].Text = _characters[cell];
        }

        public void InvalidPlay()
        {
            MessageBox.Show("Invalid Play!");
        }

        public void SessionEnded(Outcome outcome)
        {
            foreach (var button in _buttons)
            {
                button.Enabled = false;
            }

            MessageBox.Show(_outcomeMessage[outcome]);            
        }

        public void Reset()
        {
            foreach (var button in _buttons)
            {
                button.Enabled = true;
                button.Text = String.Empty;
            }
        }
    }
}
