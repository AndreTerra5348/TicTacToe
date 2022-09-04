using FluentAssertions;
using TicTacToe.Core.Board;
using TicTacToe.CoreTests.Mocks;
using TicTacToe.CoreTests.TestData;
using Xunit;

namespace TicTacToe.Core.GameOver.Draw.Tests
{
    public class DrawConditionTests
    {
        [Theory]
        [ClassData(typeof(DrawData))]
        public void Draw_CallDraw_ReturnsExpectedResult(Cell[] cells, bool expectedResult)
        {
            // Arrange
            var mockGrid = new MockGrid()
                .MockGetCells(cells);

            var sut = new DrawCondition();

            // Act
            var result = sut.Draw(mockGrid.Object);

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}