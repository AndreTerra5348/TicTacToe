using System;
using System.Windows.Forms;
using TicTacToe.Core.Board;
using TicTacToe.Core.GameOver;

namespace TicTacToe.WinForms.Views
{
    public interface IGameWindow
    {
        event EventHandler<int> CellClick;
        event EventHandler ResetClick;
        void SetCell(int index, Cell cell);
        void InvalidPlay();
        void SessionEnded(Outcome outcome);
        void Reset();
    }
}