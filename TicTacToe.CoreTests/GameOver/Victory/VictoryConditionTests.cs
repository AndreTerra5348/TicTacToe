using FluentAssertions;
using TicTacToe.Core.Board;
using TicTacToe.CoreTests.Mocks;
using Xunit;

namespace TicTacToe.Core.GameOver.Victory.Tests
{
    public class VictoryConditionTests
    {
        [Theory]
        [InlineData(new int[] { 0, 1, 2 }, true)]
        public void Won_CallWon_ReturnsExpectedResult(int[] indexes, bool expectedResult)
        {
            // Arrange
            var playerMock = new MockPlayer()
                    .MockCell(Cell.P1);

            var gridMock = new MockGrid()
                .MockIsCell(expectedResult);

            var sut = new VictoryCondition(indexes);

            // Act
            var result = sut.Won(gridMock.Object, playerMock.Object);

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}