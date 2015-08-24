namespace ExceptionsHomework
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ExceptionsHomework
    {
        public static T[] Subsequence<T>(T[] array, int startIndex, int count)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array is null");
            }

            if (startIndex < 0)
            {
                throw new ArgumentException("startIndex is less than zero");
            }

            if (count < 0)
            {
                throw new ArgumentException("count is less than zero");
            }

            if ((startIndex + count) > int.MaxValue)
            {
                throw new ArgumentException("startIndex plus count is bigger than int.MaxValue");
            }

            if (array.Length <= (startIndex + count))
            {
                throw new ArgumentOutOfRangeException("array length is smaller than startIndex plus count");
            }

            List<T> result = new List<T>();

            for (int i = startIndex; i < startIndex + count; i++)
            {
                result.Add(array[i]);
            }

            return result.ToArray();
        }

        public static string ExtractEnding(string str, int count)
        {
            if (str == null)
            {
                throw new ArgumentNullException("str is null");
            }

            if (count < 0)
            {
                throw new ArgumentException("count is less than zero");
            }

            if (count > str.Length)
            {
                throw new ArgumentOutOfRangeException("count is bigger str.Length");
            }

            StringBuilder result = new StringBuilder();

            for (int i = str.Length - count; i < str.Length; i++)
            {
                result.Append(str[i]);
            }

            return result.ToString();
        }

        public static bool CheckPrime(int number)
        {
            if (number < 0)
            {
                return false;
            }

            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static void Main()
        {
            var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
            Console.WriteLine(substr);

            var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
            Console.WriteLine(string.Join(" ", subarr));

            var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
            Console.WriteLine(string.Join(" ", allarr));

            var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
            Console.WriteLine(string.Join(" ", emptyarr));

            Console.WriteLine(ExtractEnding("I love C#", 2));
            Console.WriteLine(ExtractEnding("Nakov", 4));
            Console.WriteLine(ExtractEnding("beer", 4));
            Console.WriteLine(ExtractEnding("Hi", 100));

            if (CheckPrime(23))
            {
                Console.WriteLine("23 is prime.");
            }
            else
            {
                Console.WriteLine("23 is not prime");
            }

            if (CheckPrime(33))
            {
                Console.WriteLine("33 is prime.");
            }
            else
            {
                Console.WriteLine("33 is not prime");
            }

            List<Exam> peterExams = new List<Exam>()
                {
                    new SimpleMathExam(2),
                    new CSharpExam(55),
                    new CSharpExam(100),
                    new SimpleMathExam(1),
                    new CSharpExam(0),
                };

            Student peter = new Student("Peter", "Petrov", peterExams);
            double peterAverageResult = peter.CalcAverageExamResultInPercents();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
    }
}
