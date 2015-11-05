using System;
using System.IO;

namespace _3.FileSystem
{
    class StartUp
    {
        public static void Main(string[] args)
        {
            Folder rootFolder = new Folder() { Name = @"C:\WINDOWS" };

            BuildFileSystem(rootFolder);
            var size = CalculateSize(rootFolder);
            Console.WriteLine("Size is:{0}", size);
        }

        private static void BuildFileSystem(Folder parentFolder)
        {
            foreach (var directory in Directory.GetDirectories(parentFolder.Name))
            {
                Folder folder = new Folder() { Name = directory };

                BuildFileSystem(folder);

                parentFolder.ChildFolders.Add(folder);
            }

            foreach (var file in Directory.GetFiles(parentFolder.Name))
            {
                FileInfo fileInfo = new FileInfo(file);

                File fileNode = new File() { Name = fileInfo.Name, Size = fileInfo.Length };

                parentFolder.Files.Add(fileNode);
            }
        }

        private static long CalculateSize(Folder subFolder)
        {
            long sum = 0;

            foreach (var file in subFolder.Files)
            {
                sum += file.Size;
            }

            foreach (var folder in subFolder.ChildFolders)
            {
                sum += CalculateSize(folder);
            }

            return sum;
        }
    }
}
