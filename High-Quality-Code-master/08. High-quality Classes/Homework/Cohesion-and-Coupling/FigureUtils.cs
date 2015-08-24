namespace CohesionAndCoupling
{
    using System;

    public static class FigureUtils
    {
        public static double CalcVolume(double width, double height, double depth)
        {
            Check("width", width);
            Check("height", height);
            Check("depth", depth);

            double volume = width * height * depth;

            return volume;
        }

        public static double CalcDiagonalXYZ(double width, double height, double depth)
        {
            Check("width", width);
            Check("height", height);
            Check("depth", depth);

            double distance = MathUtils.CalcDistance3D(0, 0, 0, width, height, depth);

            return distance;
        }

        public static double CalcDiagonalXY(double width, double height)
        {
            Check("width", width);
            Check("height", height);

            double distance = MathUtils.CalcDistance2D(0, 0, width, height);

            return distance;
        }

        public static double CalcDiagonalXZ(double width, double depth)
        {
            Check("width", width);
            Check("depth", depth);

            double distance = MathUtils.CalcDistance2D(0, 0, width, depth);

            return distance;
        }

        public static double CalcDiagonalYZ(double height, double depth)
        {
            Check("height", height);
            Check("depth", depth);

            double distance = MathUtils.CalcDistance2D(0, 0, height, depth);

            return distance;
        }

        private static void Check(string name, double value)
        {
            if (value <= 0)
            {
                throw new ArgumentException(name + " <= 0");
            }
        }
    }
}
