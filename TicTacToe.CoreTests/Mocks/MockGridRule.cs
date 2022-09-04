using Moq;
using TicTacToe.Core;
using TicTacToe.Core.Board.Rules;

namespace TicTacToe.CoreTests.Mocks
{
    class MockGridRule : Mock<IGridRule>
    {
        public MockGridRule MockIsPlayAllowed(bool result)
        {
            Setup(x => x.IsPlayAllowed(It.IsAny<IPlay>()))
                .Returns(result);

            return this;
        }
    }
}
