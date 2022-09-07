using System;
using TicTacToe.Core.Board;

namespace TicTacToe.Core
{
    public sealed class Player : IPlayer
    {
        public static readonly IPlayer P1 = new Player(Cell.P1);
        public static readonly IPlayer P2 = new Player(Cell.P2);
        public Cell Cell { get; }

        private Player(Cell cell)
        {
            if (cell != Cell.P1 && cell != Cell.P2)
                throw new ArgumentException("Invalid argument!");
            Cell = cell;
        }
    }
}
