namespace Methods
{
    using System;

    public class Methods
    {
        public static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

            return area;
        }

        public static string NumberToDigit(int number)
        {
            switch (number)
            {
                case 0:
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    throw new ArgumentException("invalid number");
            }
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("elements");
            }

            if (elements.Length == 0)
            {
                throw new ArgumentException("elements.Length == 0");
            }

            int max = elements[0];

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > max)
                {
                    max = elements[i];
                }
            }

            return max;
        }

        public static void PrintAsFormatedNumber(object number, string format)
        {
            if (number == null)
            {
                throw new ArgumentNullException("number");
            }

            double value;
            if (!double.TryParse(number.ToString(), out value))
            {
                throw new ArgumentException("number isn't number");
            }

            if (format == null)
            {
                throw new ArgumentNullException("format");
            }

            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }
            else if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            }
            else if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
            else
            {
                throw new NotSupportedException(format);
            }
        }

        public static double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            if (x1 == x2 && y1 == y2)
            {
                return 0;
            }

            double powResultOfX = (x2 - x1) * (x2 - x1);
            double powResultOfY = (y2 - y1) * (y2 - y1);
            double sum = powResultOfX + powResultOfY;

            double distance = Math.Sqrt(sum);

            return distance;
        }

        public static bool IsEqual(double x, double y)
        {
            return x == y;
        }

        public static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));

            Console.WriteLine(NumberToDigit(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintAsFormatedNumber(1.3, "f");
            PrintAsFormatedNumber(0.75, "%");
            PrintAsFormatedNumber(2.30, "r");

            Console.WriteLine(CalculateDistance(3, -1, 3, 2.5));

            bool horizontal = IsEqual(3, 3);
            Console.WriteLine("Horizontal? " + horizontal);

            bool vertical = IsEqual(-1, 2.5);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
