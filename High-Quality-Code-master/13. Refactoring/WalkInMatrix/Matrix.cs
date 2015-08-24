namespace WalkInMatrix
{
    using System;
    using System.Text;

    public class Matrix
    {
        private readonly int[,] matrix;

        public Matrix(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("can't have negative columns and rows for matrix");
            }

            this.matrix = new int[n, n];
        }

        public int this[int row, int column]
        {
            get
            {
                this.RowColumnCheck(row, column);

                return this.matrix[row, column];
            }

            set
            {
                this.RowColumnCheck(row, column);

                this.matrix[row, column] = value;
            }
        }

        public Position FirstOrDefaultZeroCell()
        {
            int length = this.matrix.GetLength(0);

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (this.matrix[i, j] == 0)
                    {
                        return new Position(j, i);
                    }
                }
            }

            return default(Position);
        }

        public bool IsValidCoordinate(int row, int column)
        {
            if (row < 0 || this.matrix.GetLength(0) <= row)
            {
                return false;
            }

            if (column < 0 || this.matrix.GetLength(0) <= column)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            int length = this.matrix.GetLength(0);

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    stringBuilder.Append(this.matrix[i, j] + " ");
                }

                stringBuilder.AppendLine(string.Empty);
            }

            return stringBuilder.ToString();
        }

        private void RowColumnCheck(int row, int column)
        {
            if (!this.IsValidCoordinate(row, column))
            {
                throw new ArgumentException("row is invalid");
            }
        }
    }
}
