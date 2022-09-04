using TicTacToe.Core;
using TicTacToe.Terminal.Presenter;

namespace TicTacToe.Terminal
{
    class Worker
    {
        private readonly IGamePresenter _gamePresenter;
        public Worker(IGamePresenter gamePresenter)
        {
            _gamePresenter = gamePresenter;
        }

        public void Run()
        {
            _gamePresenter.Run();
        }
    }
}
