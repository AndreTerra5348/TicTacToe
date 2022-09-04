using System.Collections.Generic;

namespace TicTacToe.Core.Board.Rules
{
    public class GridRulesFactory
    {
        public static IGridRule[] Create(IGrid board)
        {
            return new IGridRule[]
            {
                new EmptyCellRule(board)
            };
        }
    }
}
