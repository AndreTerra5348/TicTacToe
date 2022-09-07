using System;
using TicTacToe.Core;
using TicTacToe.Core.Board;
using TicTacToe.Core.GameOver;
using TicTacToe.Terminal.Views;

namespace TicTacToe.Terminal.Presenter
{
    public class GamePresenter : IGamePresenter
    {
        private readonly IGame _game;
        private readonly IGameView _view;
        private bool _isPlaying = true;

        public GamePresenter(IGame game, IGameView view)
        {
            _game = game;
            _view = view;

            _view.Played += View_Played;
            _view.Exited += View_Exited;
            _view.Restarted += View_Restarted;
        }

        private void View_Restarted(object sender, EventArgs e)
        {
            _game.Reset();
            _view.Reset();
        }

        private void View_Exited(object sender, EventArgs e)
        {
            _isPlaying = false;
        }

        private void View_Played(object sender, int index)
        {
            var play = new Play(index, _game.CurrentPlayer);

            if (!_game.IsPlayValid(play))
            {
                _view.InvalidPlay();
                return;
            }

            _game.Play(play);
            _view.SetCell(play.Index, play.Player.Cell);

            if (_game.Won())
            {
                _view.SessionEnded(_game.CurrentPlayer.Cell == Cell.P1 ? Outcome.P1Victory : Outcome.P2Victory);
                _game.SwitchPlayer();
                return;
            }

            if (_game.Draw())
            {
                _view.SessionEnded(Outcome.Draw);
                _game.SwitchPlayer();
                return;
            }

            _game.SwitchPlayer();
        }

        public void Run()
        {
            _view.Reset();
            while (_isPlaying)
            {
                _view.TurnBegin();
            }
        }
    }
}
