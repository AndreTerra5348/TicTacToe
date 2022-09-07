using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TicTacToe.Core;
using TicTacToe.Core.GameOver;
using TicTacToe.Core.Validator;
using TicTacToe.MAUI.Services;

using Cell = TicTacToe.Core.Board.Cell;

namespace TicTacToe.MAUI.ViewModels
{
    public class GridViewModel : INotifyPropertyChanged
    {
        private readonly IGame _game;
        private readonly IIndexValidator _indexValidator;
        private readonly IAlertService _alertService;

        public event PropertyChangedEventHandler PropertyChanged;
        public Cell[] Cells { get; private set; }
        public ICommand PlayCommand { get; private set; }
        public ICommand ResetCommand { get; private set; }
        public ICommand ExitCommand { get; internal set; }

        public GridViewModel(IGame game, IIndexValidator indexValidator, IAlertService alertService)
        {
            _game = game;
            _indexValidator = indexValidator;
            _alertService = alertService;

            Cells = Enumerable.Repeat(Cell.Empty, Core.Board.Grid.Size).ToArray();
            PlayCommand = new Command<string>(Play, CanPlay);
            ResetCommand = new Command(Reset);
            ExitCommand = new Command(_ => Application.Current.Quit());
        }

        private bool CanPlay(string parameter)
        {
            if (!int.TryParse(parameter, out int index))
                return false;

            if (!_indexValidator.IsValid(index))
                return false;

            return Cells[index] == Cell.Empty;
        }

        private void Play(string parameter)
        {
            if (!int.TryParse(parameter, out int index))
                return;

            if (!_indexValidator.IsValid(index))
                return;

            var play = new Play(index, _game.CurrentPlayer);

            if (!_game.IsPlayValid(play))
                return;

            _game.Play(play);
            Cells[index] = _game.CurrentPlayer.Cell;
            OnNotifyPropertyChanged(nameof(Cells));

            if (_game.Won())
            {
                SessionEnded(_game.CurrentPlayer.Cell == Cell.P1 ? Outcome.P1Victory : Outcome.P2Victory);
            }
            else if (_game.Draw())
            {
                SessionEnded(Outcome.Draw);
            }

            _game.SwitchPlayer();
        }

        private void OnNotifyPropertyChanged([CallerMemberName] string propName = null)
        {
            var handler = PropertyChanged;
            if(handler != null)
                handler.Invoke(this, new PropertyChangedEventArgs(propName));
        }


        private void Reset()
        {
            _game.Reset();
            for(int i = 0; i < Cells.Length; i++)
            {
                Cells[i] = Cell.Empty;
            }
            OnNotifyPropertyChanged(nameof(Cells));
        }

        private void SessionEnded(Outcome outcome)
        {
            var outcomeString = GetOutcomeString(outcome);
            _alertService.ShowConfirmation("Game Over!", outcomeString, accept: "Reset", cancel: "Exit", callback: ConfirmationCallback);
        }

        private void ConfirmationCallback(bool restart)
        {
            if (restart)
                ResetCommand.Execute(null);
            else
                ExitCommand.Execute(null);
        }

        private string GetOutcomeString(Outcome outcome)
        {
            return outcome switch
            {
                Outcome.P1Victory => "Player 1 Won!",
                Outcome.P2Victory => "Player 2 Won!",
                Outcome.Draw => "Draw!",
                _ => throw new InvalidDataException(),
            };
        }

    }
}
