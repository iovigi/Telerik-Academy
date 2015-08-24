namespace _2.Matrix
{
    using System;

    public class Matrix
    {
        public const int MIN_X = 0;
        public const int MAX_X = 100;
        public const int MIN_Y = 0;
        public const int MAX_Y = 100;

        public void EnumarateMatrix()
        {
            int x = 0;
            int y = 0;
            bool shouldNotVisitCell = false;

            if (!shouldNotVisitCell)
            {
                if ((MIN_X <= x && x <= MAX_X) && (MIN_Y <= y && y <= MAX_Y))
                {
                    this.VisitCell();
                }
            }
        }

        private void VisitCell()
        {
            throw new NotImplementedException();
        }
    }
}
