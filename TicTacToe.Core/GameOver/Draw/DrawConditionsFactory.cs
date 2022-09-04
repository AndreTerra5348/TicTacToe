using System.Collections.Generic;

namespace TicTacToe.Core.GameOver.Draw
{
    public class DrawConditionsFactory
    {
        public static IDrawCondition[] Create()
        {
            return new IDrawCondition[]
            {
                new DrawCondition()
            };
        }
    }
}
