namespace Matrix.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using WalkInMatrix;

    [TestClass]
    public class MatrixTest
    {
        [TestMethod]
        public void CreateValidMatrix()
        {
            var matrix = new Matrix(3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateInvalidMatrix()
        {
            var matrix = new Matrix(-1);
        }

        [TestMethod]
        public void SetValueInCorrectRowAndColumn()
        {
            var matrix = new Matrix(3);

            matrix[1, 1] = 1;

            Assert.AreEqual(1, matrix[1, 1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetValueInIncorrectRowAndColumn()
        {
            var matrix = new Matrix(3);

            matrix[-1, -1] = 1;
        }

        [TestMethod]
        public void GetValueInCorrectRowAndColumn()
        {
            var matrix = new Matrix(3);

            Assert.AreEqual(0, matrix[1, 1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetValueInIncorrectRowAndColumn()
        {
            var matrix = new Matrix(3);

            var value = matrix[-1, -1];
        }

        [TestMethod]
        public void FirstOrDefaultZeroCellWithNotSetMatrix()
        {
            var matrix = new Matrix(3);
            var expected = new Position(0, 0);

            var actual = matrix.FirstOrDefaultZeroCell();

            Assert.AreEqual(expected.X, actual.X);
            Assert.AreEqual(expected.Y, actual.Y);
        }

        [TestMethod]
        public void FirstOrDefaultZeroCellWithMatrixWithNoZeroValue()
        {
            var matrix = new Matrix(3);
            var expected = default(Position);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrix[i, j] = 1;
                }
            }

            var actual = matrix.FirstOrDefaultZeroCell();


            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsValidCoordinateWithValidCoordinate()
        {
            var matrix = new Matrix(3);

            var actual = matrix.IsValidCoordinate(0, 0);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsValidCoordinateWithInvalidCoordinate()
        {
            var matrix = new Matrix(3);

            var actual = matrix.IsValidCoordinate(-1, -1);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ToString()
        {
            var matrix = new Matrix(3);
            var expected = "0 0 0 \r\n0 0 0 \r\n0 0 0 \r\n";

            var actual = matrix.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
