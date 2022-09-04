using Moq;
using TicTacToe.Core;
using TicTacToe.Core.Board;

namespace TicTacToe.CoreTests.Mocks
{
    class MockPlayer : Mock<IPlayer>
    {
        public MockPlayer MockCell(Cell cell)
        {
            Setup(x => x.Cell)
                .Returns(cell);
            return this;
        }
    }
}
