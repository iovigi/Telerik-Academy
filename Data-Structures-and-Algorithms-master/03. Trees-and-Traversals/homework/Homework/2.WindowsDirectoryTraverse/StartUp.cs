using System;
using System.IO;

namespace _2.WindowsDirectoryTraverse
{
    class StartUp
    {
        static void Main(string[] args)
        {
            foreach (var file in Directory.GetFileSystemEntries("C:\\WINDOWS","*.exe",SearchOption.AllDirectories))
            {
                Console.WriteLine(file.ToString());
            }
        }
    }
}
