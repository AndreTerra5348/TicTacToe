using Moq;
using TicTacToe.Core.Board;
using TicTacToe.Core.GameOver.Draw;

namespace TicTacToe.CoreTests.Mocks
{
    class MockDrawCondition : Mock<IDrawCondition>
    {
        public MockDrawCondition MockDraw(bool result)
        {
            Setup(x => x.Draw(It.IsAny<IGrid>()))
                .Returns(result);

            return this;
        }
    }
}
