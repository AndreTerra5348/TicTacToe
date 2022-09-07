using TicTacToe.Core;
using FluentAssertions;
using Moq;
using TicTacToe.Core.Board;
using TicTacToe.Core.Board.Rules;
using TicTacToe.Core.GameOver.Draw;
using TicTacToe.Core.GameOver.Victory;
using TicTacToe.CoreTests.Mocks;
using Xunit;

namespace TicTacToe.Core.Tests
{
    public class GameTests
    {
        [Fact]
        public void Reset_CallReset_OnlyOnce()
        {
            // Arrange
            var mockGrid = new MockGrid()
                .MockReset();

            var sut = new Game(mockGrid.Object,
                new IVictoryCondition[] { },
                new IDrawCondition[] { },
                new IGridRule[] { }
                );

            // Act
            sut.Reset();

            // Assert
            mockGrid.Verify(x => x.Reset(), Times.Once);
        }
        [Fact]
        public void SwitchPlayer_CallSwithPlayer_ChangePlayerToP2()
        {
            // Arrange
            var mockGrid = new MockGrid();

            var sut = new Game(mockGrid.Object,
                new IVictoryCondition[] { },
                new IDrawCondition[] { },
                new IGridRule[] { }
                );


            // Act
            sut.SwitchPlayer();

            // Assert
            sut.CurrentPlayer.Should().Be(Player.P2);
        }

        [Fact]
        public void Play_CallPlay_OnlyOnce()
        {
            // Arrange
            var mockGrid = new MockGrid()
                .MockSetCell();

            var mockPlayer = new MockPlayer()
                .MockCell(Cell.P1);

            var mockPlay = new MockPlay()
                .MockIndex(0)
                .MockPlayer(mockPlayer.Object);

            var sut = new Game(mockGrid.Object,
                new IVictoryCondition[] { },
                new IDrawCondition[] { },
                new IGridRule[] { }
                );

            // Act
            sut.Play(mockPlay.Object);

            //Assert
            mockGrid.Verify(x => x.SetCell(It.IsAny<int>(), It.IsAny<Cell>()), Times.Once);
        }

        [Theory]
        [InlineData(true)]
        public void IsPlayValid_CallIsPlayValid_ReturnsExpectedResult(bool expectedValue)
        {
            // Arrange
            var mockGrid = new MockGrid();

            var mockGridRule = new MockGridRule()
                .MockIsPlayAllowed(expectedValue);

            var mockPlay = new MockPlay();

            var sut = new Game(mockGrid.Object,
                new IVictoryCondition[] { },
                new IDrawCondition[] { },
                new IGridRule[] { mockGridRule.Object }
                );

            // Act
            var result = sut.IsPlayValid(mockPlay.Object);

            // Assert
            result.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData(true)]
        public void Won_CallWon_ReturnsExpectedResult(bool expectedValue)
        {
            // Arrange
            var mockGrid = new MockGrid();

            var mockVictoryCondition = new MockVictoryCondition()
                .MockWon(expectedValue);

            var sut = new Game(mockGrid.Object,
                new IVictoryCondition[] { mockVictoryCondition.Object },
                new IDrawCondition[] { },
                new IGridRule[] { }
                );

            // Act
            var result = sut.Won();

            // Assert
            result.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData(true)]
        public void Draw_CallDraw_ReturnsExpectedResult(bool expectedResult)
        {
            // Arrange
            var mockGrid = new MockGrid();

            var mockDrawCondition = new MockDrawCondition()
                .MockDraw(expectedResult);

            var sut = new Game(mockGrid.Object,
                new IVictoryCondition[] { },
                new IDrawCondition[] { mockDrawCondition.Object },
                new IGridRule[] { }
                );

            // Act
            var result = sut.Draw();

            // Assert
            result.Should().Be(expectedResult);
        }        
    }
}