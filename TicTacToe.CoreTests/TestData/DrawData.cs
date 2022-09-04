using System.Collections;
using System.Collections.Generic;

namespace TicTacToe.CoreTests.TestData
{
    class DrawData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                GridScenario.AllEmpty, false
            };
            yield return new object[]
            {
                GridScenario.P1WonFirstRow, false
            };
            yield return new object[]
            {
                GridScenario.Draw, true
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
