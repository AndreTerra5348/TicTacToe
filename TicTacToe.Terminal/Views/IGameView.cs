using System;
using TicTacToe.Core.GameOver;

namespace TicTacToe.Terminal.Views
{
    public interface IGameView
    {
        EventHandler<IInput> Played { get; set; }
        EventHandler Exited { get; set; }
        EventHandler Restarted { get; set; }
        void TurnBegin();
        void InvalidPlay();
        void SessionEnded(Outcome outcome);
        void Start();
    }
}
