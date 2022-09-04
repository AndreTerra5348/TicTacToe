using System;
using System.Collections.Generic;
using TicTacToe.Core.GameOver;

namespace TicTacToe.Terminal.Views
{
    class GameView : IGameView
    {
        private readonly IGridView _gridView;

        public static readonly int ExitValue = -1;

        private readonly Dictionary<Outcome, string> _outcomeMessage = new Dictionary<Outcome, string>()
        {
            { Outcome.P1Victory, "Player 1 Won!" },
            { Outcome.P2Victory, "Player 2 Won!" },
            { Outcome.Draw, "Draw!" },
        };

        public EventHandler<IInput> Played { get; set; }
        public EventHandler Exited { get; set; }
        public EventHandler Restarted { get; set; }

        public GameView(IGridView gridView)
        {
            _gridView = gridView;
        }

        public void Start()
        {
            _gridView.Draw();
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
            while (!int.TryParse(line, out index))
            {
                Console.WriteLine("Invalid input.");
                line = Console.ReadLine();
            }
            return index;
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
                handler.Invoke(this, new Input(index));
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
