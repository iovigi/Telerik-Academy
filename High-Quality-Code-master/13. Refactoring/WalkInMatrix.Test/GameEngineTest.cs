namespace Matrix.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WalkInMatrix;

    [TestClass]
    public class GameEngineTest
    {
        [TestMethod]
        public void CreateValidEngine()
        {
            var engine = new GameEngine(3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateInvalidEngine()
        {
            var engine = new GameEngine(0);
        }

        [TestMethod]
        public void CreateEngineWork()
        {
            var engine = new GameEngine(6);
            string expected = "1 16 17 18 19 20 \r\n15 2 27 28 29 21 \r\n14 31 3 26 30 22 \r\n13 36 32 4 25 23 \r\n12 35 34 33 5 24 \r\n11 10 9 8 7 6 \r\n";

            engine.Start();

            Assert.AreEqual(expected, engine.BoardToString());
        }

        [TestMethod]
        public void CreateEnginePrintWithoutStart()
        {
            var engine = new GameEngine(6);
            string expected = string.Empty;

            var actual = engine.BoardToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
