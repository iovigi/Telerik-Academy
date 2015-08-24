namespace AdvancedMathComparer
{
    public class Tests
    {
        public static void Main(string[] args)
        {
            int countOfTest = 10000;

            SquareRootComparer.Compare(countOfTest);
            NaturalLogarithmComparer.Compare(countOfTest);
            SinusComparer.Compare(countOfTest);
        }
    }
}
