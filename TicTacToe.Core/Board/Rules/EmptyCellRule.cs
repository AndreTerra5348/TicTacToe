namespace TicTacToe.Core.Board.Rules
{
    public class EmptyCellRule : IGridRule
    {
        private readonly IGrid _grid;

        public EmptyCellRule(IGrid grid)
        {
            _grid = grid;
        }

        public bool IsPlayAllowed(IPlay play)
        {
            return _grid.IsCell(play.Index, Cell.Empty);
        }
    }
}
