using System;
using TicTacToe.Core.Board;
using TicTacToe.Core.GameOver;

namespace TicTacToe.Terminal.Views
{
    public interface IGameView
    {
        EventHandler<int> Played { get; set; }
        EventHandler Exited { get; set; }
        EventHandler Restarted { get; set; }
        void TurnBegin();
        void InvalidPlay();
        void SessionEnded(Outcome outcome);
        void Reset();
        void SetCell(int index, Cell cell);
    }
}
