namespace Matrix.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.IO;
    using WalkInMatrix;

    [TestClass]
    public class ExecutorTest
    {
        [TestMethod]
        public void Main()
        {
            using (StringWriter testStringWriter = new StringWriter())
            {
                Console.SetOut(testStringWriter);
                string expected = "1 16 17 18 19 20 \r\n15 2 27 28 29 21 \r\n14 31 3 26 30 22 \r\n13 36 32 4 25 23 \r\n12 35 34 33 5 24 \r\n11 10 9 8 7 6 \r\n\r\n";

                Executor.Main();

                Assert.AreEqual(expected, testStringWriter.ToString());
            }
        }
    }
}
