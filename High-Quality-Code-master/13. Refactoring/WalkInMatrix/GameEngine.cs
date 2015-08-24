namespace WalkInMatrix
{
    using System;

    public class GameEngine
    {
        public readonly int Size;

        private readonly Position[] possibleDirections = new Position[] { new Position(1, 1), new Position(0, 1), new Position(-1, 1), new Position(-1, 0), new Position(-1, -1), new Position(0, -1), new Position(1, -1), new Position(1, 0), };

        private Matrix matrix;
        private int currentDirection;

        public GameEngine(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("size can't be less than one");
            }

            this.Size = size;
        }

        public void Start()
        {
            this.matrix = new Matrix(this.Size);

            Position currentPosition = new Position(0, 0);
            int cellValue = 0;

            do
            {
                this.currentDirection = 0;

                do
                {
                    this.matrix[currentPosition.Y, currentPosition.X] = ++cellValue;
                }
                while (this.Move(currentPosition, out currentPosition));

                currentPosition = this.matrix.FirstOrDefaultZeroCell();
            }
            while (currentPosition != null);
        }

        public string BoardToString()
        {
            if (this.matrix == null)
            {
                return string.Empty;
            }

            return this.matrix.ToString();
        }

        private bool Move(Position startPosition, out Position position)
        {
            var length = this.possibleDirections.Length;

            for (int i = 0; i < length; i++)
            {
                var possibleDirection = this.possibleDirections[this.currentDirection];
                var row = startPosition.Y + possibleDirection.Y;
                var column = startPosition.X + possibleDirection.X;

                if (this.matrix.IsValidCoordinate(row, column) && this.matrix[row, column] == 0)
                {
                    position = new Position(column, row);

                    return true;
                }

                this.currentDirection++;

                if (this.currentDirection == length)
                {
                    this.currentDirection = 0;
                }
            }

            position = default(Position);

            return false;
        }
    }
}
