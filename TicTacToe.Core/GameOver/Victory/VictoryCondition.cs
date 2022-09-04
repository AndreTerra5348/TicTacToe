using TicTacToe.Core.Board;

namespace TicTacToe.Core.GameOver.Victory
{
    public class VictoryCondition : IVictoryCondition
    {
        private readonly int[] _indexes;

        public VictoryCondition(int[] indexes)
        {
            _indexes = indexes;
        }

        public bool Won(IGrid grid, IPlayer player)
        {
            foreach (int index in _indexes)
            {
                if (!grid.IsCell(index, player.Cell))
                    return false;
            }
            return true;
        }
    }
}
