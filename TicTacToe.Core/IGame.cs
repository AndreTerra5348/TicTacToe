namespace TicTacToe.Core
{
    public interface IGame
    {
        IPlayer CurrentPlayer { get; }
        bool Draw();
        bool IsPlayValid(IPlay play);
        void Play(IPlay play);
        void SwitchPlayer();
        bool Won();
        void Reset();
    }
}