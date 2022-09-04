using System.Collections.Generic;

namespace TicTacToe.Core.GameOver.Victory
{
    public class VictoryConditionsFactory
    {
        public static IVictoryCondition[] Create()
        {
            return new IVictoryCondition[]
            {
                // Rows
                new VictoryCondition(new int[]{ 0, 1, 2 }),
                new VictoryCondition(new int[]{ 3, 4, 5 }),
                new VictoryCondition(new int[]{ 6, 7, 8 }),

                // Columns
                new VictoryCondition(new int[]{ 0, 3, 6 }),
                new VictoryCondition(new int[]{ 1, 4, 7 }),
                new VictoryCondition(new int[]{ 2, 5, 8 }),

                // Diagonals
                new VictoryCondition(new int[]{ 0, 4, 8 }),
                new VictoryCondition(new int[]{ 2, 4, 6 }),
            };
        }
    }
}
