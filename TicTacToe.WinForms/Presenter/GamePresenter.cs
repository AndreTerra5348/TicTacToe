using System;
using TicTacToe.Core;
using TicTacToe.Core.Board;
using TicTacToe.Core.GameOver;
using TicTacToe.WinForms.Views;

namespace TicTacToe.WinForms.Presenter
{
    class GamePresenter : IGamePresenter
    {
        private readonly IGame _game;
        public IGameWindow View { get; }

        public GamePresenter(IGame game, IGameWindow view)
        {
            _game = game;
            View = view;

            View.CellClick += View_CellClick;
            View.ResetClick += View_ResetClick;

        }

        private void View_ResetClick(object sender, EventArgs e)
        {
            _game.Reset();
            View.Reset();
        }

        private void View_CellClick(object sender, int index)
        {
            var play = new Play(index, _game.Player);
            if (!_game.IsPlayValid(play))
            {
                View.InvalidPlay();
                return;
            }

            Console.WriteLine("Click " + index);
            _game.Play(play);
            View.SetCell(play.Index, play.Player.Cell);

            if (_game.Won())
            {
                View.SessionEnded(_game.Player.Cell == Cell.P1 ? Outcome.P1Victory : Outcome.P2Victory);
                _game.SwitchPlayer();
            }

            if (_game.Draw())
            {
                View.SessionEnded(Outcome.Draw);
                _game.SwitchPlayer();
                return;
            }

            _game.SwitchPlayer();
        }
    }
}
