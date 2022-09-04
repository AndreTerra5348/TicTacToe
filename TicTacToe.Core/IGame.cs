namespace TicTacToe.Core
{
    public interface IGame
    {
        Player Player { get; }

        bool Draw();
        bool IsPlayValid(IPlay play);
        void Play(IPlay play);
        void SwitchPlayer();
        bool Won();
        void Reset();
    }
}