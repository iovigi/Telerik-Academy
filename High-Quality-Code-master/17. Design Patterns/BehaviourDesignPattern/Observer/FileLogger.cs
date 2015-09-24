using System.IO;

namespace Observer
{
    public class FileLogger : ILogger
    {
        public void Log(string text)
        {
            using (FileStream stream = new FileStream("Log.txt", FileMode.OpenOrCreate))
            {
                StreamWriter writer = new StreamWriter(stream);

                writer.WriteLine(text);
            }
        }
    }
}
