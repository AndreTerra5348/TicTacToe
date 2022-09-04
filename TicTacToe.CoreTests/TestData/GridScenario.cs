using TicTacToe.Core.Board;

namespace TicTacToe.CoreTests.TestData
{
    class GridScenario
    {
        public static readonly Cell[] AllEmpty = new Cell[]
        {
            Cell.Empty, Cell.Empty, Cell.Empty,
            Cell.Empty, Cell.Empty, Cell.Empty,
            Cell.Empty, Cell.Empty, Cell.Empty
        };

        public static readonly Cell[] P1WonFirstRow = new Cell[]
        {
            Cell.P1, Cell.P1, Cell.P1,
            Cell.Empty, Cell.Empty, Cell.Empty,
            Cell.Empty, Cell.Empty, Cell.Empty
        };

        public static readonly Cell[] P2WonDiagonal = new Cell[]
        {
            Cell.P2, Cell.Empty, Cell.Empty,
            Cell.Empty, Cell.P2, Cell.Empty,
            Cell.Empty, Cell.Empty, Cell.P2
        };

        public static readonly Cell[] Draw = new Cell[]
        {
            Cell.P1, Cell.P2, Cell.P1,
            Cell.P1, Cell.P1, Cell.P2,
            Cell.P2, Cell.P1, Cell.P2
        };
    }
}
