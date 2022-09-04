using TicTacToe.WinForms.Views;

namespace TicTacToe.WinForms.Presenter
{
    internal interface IGamePresenter
    {
        IGameWindow View { get; }
    }
}