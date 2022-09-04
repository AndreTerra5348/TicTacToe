using FluentAssertions;
using Moq;
using TicTacToe.CoreTests.Mocks;
using Xunit;

namespace TicTacToe.Core.Board.Rules.Tests
{
    public class EmptyCellRuleTests
    {
        [Theory]
        [InlineData(true)]
        public void IsPlayAllowed_CallIsPlayAllowed_ReturnsExpectedResult(bool expectedResult)
        {
            // Arrange
            var mockGrid = new MockGrid()
                .MockIsCell(expectedResult);

            var mockPlayer = new MockPlayer();

            var mockPlay = new MockPlay()
                .MockIndex(0)
                .MockPlayer(mockPlayer.Object);

            var sut = new EmptyCellRule(mockGrid.Object);

            // Act
            var result = sut.IsPlayAllowed(mockPlay.Object);

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}