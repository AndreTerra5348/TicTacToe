using System;
using System.Collections.Generic;
using TicTacToe.Core.Board;
using TicTacToe.Core.GameOver;
using TicTacToe.Core.Validator;

namespace TicTacToe.Terminal.Views
{
    class GameView : IGameView
    {
        private readonly IGridView _gridView;
        private readonly IIndexValidator _indexValidator;

        public static readonly int ExitValue = -1;

        private readonly Dictionary<Outcome, string> _outcomeMessage = new Dictionary<Outcome, string>()
        {
            { Outcome.P1Victory, "Player 1 Won!" },
            { Outcome.P2Victory, "Player 2 Won!" },
            { Outcome.Draw, "Draw!" },
        };

        public EventHandler<int> Played { get; set; }
        public EventHandler Exited { get; set; }
        public EventHandler Restarted { get; set; }


        public GameView(IGridView gridView, IIndexValidator indexValidator)
        {
            _gridView = gridView;
            _indexValidator = indexValidator;
        }

        public void Reset()
        {
            _gridView.Reset();
        }

        public void TurnBegin()
        {
            Console.WriteLine(string.Format("Enter the index or {0} to exit:", ExitValue));
            var index = ReadIndex();
            if (index == ExitValue)
                OnExited();
            else
                OnPlayed(index);
        }        

        private int ReadIndex()
        {
            int index = ExitValue;
            var line = Console.ReadLine();
            while (!int.TryParse(line, out index) || !_indexValidator.IsValid(index))
            {
                Console.WriteLine("Invalid input.");
                line = Console.ReadLine();
            }
            return index;
        }

        bool IsIndexValid(int index)
        {
            return index >= 0 && index < Grid.Size;
        }

        public void SetCell(int index, Cell cell)
        {
            _gridView.SetCell(index, cell);
        }

        public void InvalidPlay()
        {
            Console.WriteLine("Invalid index.");
        }

        public void SessionEnded(Outcome outcome)
        {
            Console.WriteLine(_outcomeMessage[outcome]);
            Console.WriteLine("Press Enter to restart or -1 to quit");

            var line = Console.ReadLine();
            if (line == ExitValue.ToString())
                OnExited();
            else
                OnRestart();

        }

        private void OnPlayed(int index)
        {
            var handler = Played;
            if (handler != null)
                handler.Invoke(this, index);
        }

        private void OnExited()
        {
            var handler = Exited;
            if (handler != null)
                handler.Invoke(this, EventArgs.Empty);
        }

        private void OnRestart()
        {
            var handler = Restarted;
            if (handler != null)
                handler.Invoke(this, EventArgs.Empty);
        }

        
    }
}
