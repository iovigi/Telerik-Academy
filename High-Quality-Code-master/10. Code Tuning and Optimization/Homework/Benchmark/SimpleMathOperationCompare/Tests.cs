namespace SimpleMathOperationComparer
{
    public class Tests
    {
        public static void Main(string[] args)
        {
            int countOfTest = 10000;

            AddComparer.Compare(countOfTest);
            SubtrackComparer.Compare(countOfTest);
            IncrementComparer.Compare(countOfTest);
            MultiplyComparer.Compare(countOfTest);
            DivideComparer.Compare(countOfTest);
        }
    }
}
