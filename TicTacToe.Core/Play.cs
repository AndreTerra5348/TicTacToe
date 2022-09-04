using System;

namespace TicTacToe.Core
{
    public class Play : IPlay
    {
        public int Index { get; }
        public IPlayer Player { get; }

        public Play(int index, IPlayer player)
        {
            Index = index;
            Player = player;
        }

    }
}
