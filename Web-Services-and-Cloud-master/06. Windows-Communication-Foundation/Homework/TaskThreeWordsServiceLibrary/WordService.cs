namespace TaskThreeWordsServiceLibrary
{
    public class WordService : IWordService
    {
        public int GetTimesOfMuch(string firstWord, string secondWord)
        {
            int count = 0;
            int index = 0;

            while (true)
            {
                index = secondWord.IndexOf(firstWord, index);

                if (index == -1)
                {
                    break;
                }

                index++;
                count++;
            }

            return count;
        }
    }
}
