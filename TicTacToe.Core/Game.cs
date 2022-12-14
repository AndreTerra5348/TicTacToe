using System.Collections.Generic;
using TicTacToe.Core.Board;
using TicTacToe.Core.Board.Rules;
using TicTacToe.Core.GameOver.Draw;
using TicTacToe.Core.GameOver.Victory;

namespace TicTacToe.Core
{
    public class Game : IGame
    {
        private readonly IGrid _grid;
        public static readonly IPlayer StartPlayer = Player.P1;

        public IPlayer CurrentPlayer { get; private set; }


        private readonly IEnumerable<IVictoryCondition> _victoryConditions;
        private readonly IEnumerable<IDrawCondition> _drawConditions;
        private readonly IEnumerable<IGridRule> _gridRules;

        public Game(IGrid grid, 
            IEnumerable<IVictoryCondition> victoryConditions, 
            IEnumerable<IDrawCondition> drawConditions, 
            IEnumerable<IGridRule> gridRules)
        {
            _grid = grid;
            _victoryConditions = victoryConditions;
            _drawConditions = drawConditions;
            _gridRules = gridRules;
            CurrentPlayer = StartPlayer;
        }

        public void Reset()
        {
            _grid.Reset();
        }

        public void SwitchPlayer()
        {
            CurrentPlayer = CurrentPlayer.Cell == Player.P1.Cell ? Player.P2 : Player.P1;
        }

        public void Play(IPlay play)
        {
            _grid.SetCell(play.Index, play.Player.Cell);
        }

        public bool IsPlayValid(IPlay play)
        {
            foreach (var rule in _gridRules)
            {
                if (!rule.IsPlayAllowed(play))
                    return false;
            }
            return true;
        }

        public bool Won()
        {
            foreach (var condition in _victoryConditions)
            {
                if (condition.Won(_grid, CurrentPlayer))
                    return true;
            }
            return false;
        }

        public bool Draw()
        {
            foreach(var condition in _drawConditions)
            {
                if (condition.Draw(_grid))
                    return true;
            }
            return false;
        }

    }
}
