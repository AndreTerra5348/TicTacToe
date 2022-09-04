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
        public event EventHandler<int> CellClick
        {
            add { gridControl.ButtonClick += value; }
            remove { gridControl.ButtonClick -= value; }
        }
        public event EventHandler ResetClick;

        private readonly Dictionary<Outcome, string> _outcomeMessage = new Dictionary<Outcome, string>()
        {
            { Outcome.P1Victory, "Player 1 Won!" },
            { Outcome.P2Victory, "Player 2 Won!" },
            { Outcome.Draw, "Draw!" },
        };

        public GameWindow()
        {
            InitializeComponent();
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
            gridControl.SetCell(index, cell);
        }

        public void InvalidPlay()
        {
            MessageBox.Show("Invalid Play!");
        }

        public void SessionEnded(Outcome outcome)
        {
            MessageBox.Show(_outcomeMessage[outcome]);
        }

        public void Reset()
        {
            gridControl.Reset();
        }
    }
}
