using TicTacToe.Core.Board;

namespace TicTacToe.Core.Validator
{
    public class IndexValidator : IIndexValidator
    {
        public bool IsValid(int index)
        {
            return index >= 0 && index < Grid.Size;
        }
    }
}
