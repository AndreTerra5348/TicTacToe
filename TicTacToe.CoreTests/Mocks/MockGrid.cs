using Moq;
using System.Collections.Generic;
using TicTacToe.Core.Board;

namespace TicTacToe.CoreTests.Mocks
{
    class MockGrid : Mock<IGrid>
    {
        public MockGrid MockIsCell(bool result)
        {
            Setup(x => x.IsCell(It.IsAny<int>(), It.IsAny<Cell>()))
                    .Returns(result);
            return this;
        }

        public MockGrid MockGetCells(IEnumerable<Cell> cells)
        {
            Setup(x => x.GetCells())
                .Returns(cells);

            return this;
        }

        public MockGrid MockGetCell(Cell cell)
        {
            Setup(x => x.GetCell(It.IsAny<int>()))
                .Returns(cell);

            return this;
        }

        public MockGrid MockSetCell()
        {
            Setup(x => x.SetCell(It.IsAny<int>(), It.IsAny<Cell>()));
            return this;
        }

        public MockGrid MockReset()
        {
            Setup(x => x.Reset());
            return this;
        }
    }
}
