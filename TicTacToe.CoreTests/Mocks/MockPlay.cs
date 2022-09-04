using Moq;
using TicTacToe.Core;

namespace TicTacToe.CoreTests.Mocks
{
    class MockPlay : Mock<IPlay>
    {
        public MockPlay MockIndex(int index)
        {
            Setup(x => x.Index)
                .Returns(index);
            return this;
        }

        public MockPlay MockPlayer(IPlayer player)
        {
            Setup(x => x.Player)
                .Returns(player);

            return this;
        }
    }
}
