namespace TicTacToe.Terminal.Views
{
    public class Input : IInput
    {
        public int Index { get; }

        public Input(int index)
        {
            Index = index;
        }

    }
}
