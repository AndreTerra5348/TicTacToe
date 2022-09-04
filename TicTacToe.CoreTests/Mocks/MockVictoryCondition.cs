using Moq;
using TicTacToe.Core;
using TicTacToe.Core.Board;
using TicTacToe.Core.GameOver.Victory;

namespace TicTacToe.CoreTests.Mocks
{
    class MockVictoryCondition : Mock<IVictoryCondition>
    {
        public MockVictoryCondition MockWon(bool result)
        {
            Setup(x => x.Won(It.IsAny<IGrid>(), It.IsAny<IPlayer>()))
                .Returns(result);

            return this;
        }
    }
}
