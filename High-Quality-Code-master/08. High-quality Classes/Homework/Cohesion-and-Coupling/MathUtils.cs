namespace CohesionAndCoupling
{
    using System;

    public static class MathUtils
    {
        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            if (x1 == x2 && y1 == y2)
            {
                return 0;
            }

            double powOfX = (x2 - x1) * (x2 - x1);
            double powOfY = (y2 - y1) * (y2 - y1);

            double distance = Math.Sqrt(powOfX + powOfY);

            return distance;
        }

        public static double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            if (x1 == x2 && y1 == y2 && z1 == z2)
            {
                return 0;
            }

            double powOfX = (x2 - x1) * (x2 - x1);
            double powOfY = (y2 - y1) * (y2 - y1);
            double powOfZ = (z2 - z1) * (z2 - z1);

            double distance = Math.Sqrt(powOfX + powOfY + powOfZ);

            return distance;
        }
    }
}
