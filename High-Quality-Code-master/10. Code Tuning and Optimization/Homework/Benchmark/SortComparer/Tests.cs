namespace SortComparer
{
    public class Tests
    {
        public static void Main(string[] args)
        {
            int countOfIndexOfArray = 10000;

            InsertionSortComparer.RandomCompare(countOfIndexOfArray);
            InsertionSortComparer.SequentialCompare(countOfIndexOfArray);
            InsertionSortComparer.BackSequentialCompare(countOfIndexOfArray);
            SelectionSortComparer.RandomCompare(countOfIndexOfArray);
            SelectionSortComparer.SequentialCompare(countOfIndexOfArray);
            SelectionSortComparer.BackSequentialCompare(countOfIndexOfArray);
            QuickSortComparer.RandomCompare(countOfIndexOfArray);
            QuickSortComparer.SequentialCompare(countOfIndexOfArray);
            QuickSortComparer.BackSequentialCompare(countOfIndexOfArray);
        }
    }
}
