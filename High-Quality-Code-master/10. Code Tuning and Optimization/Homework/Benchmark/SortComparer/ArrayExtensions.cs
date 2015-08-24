namespace SortComparer
{
    using System;

    public static class ArrayExtensions
    {
        public static void Swap<T>(this T[] array, int firstIndex, int secondIndex)
        {
            if (firstIndex < 0 || array.Length <= firstIndex)
            {
                throw new ArgumentOutOfRangeException("firstIndex");
            }

            if (secondIndex < 0 || array.Length <= secondIndex)
            {
                throw new ArgumentOutOfRangeException("secondIndex");
            }

            T carryElement = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = carryElement;
        }
    }
}
