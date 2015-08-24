namespace _1.Size
{
    using System;

    public class Size
    {
        private double width;
        private double height;

        public Size(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                this.height = value;
            }
        }

        public static Size GetRotatedSize(Size size, double angleOfTheFigure)
        {
            double cosOfAngle = Math.Cos(angleOfTheFigure);
            double absoluteValueOfCos = Math.Abs(cosOfAngle);

            double sinOfAngle = Math.Sin(angleOfTheFigure);
            double absoluteValueOfSin = Math.Abs(sinOfAngle);

            double rotatedWidth = (absoluteValueOfCos * size.Width) + (absoluteValueOfSin * size.Height);
            double rotatedHeight = (absoluteValueOfSin * size.Width) + (absoluteValueOfCos * size.Height);

            return new Size(rotatedWidth, rotatedHeight);
        }
    }
}
