using System.Collections.Generic;

namespace _3.FileSystem
{
    public class Folder
    {
        public string Name { get; set; }
        public List<File> Files { get; private set; }
        public List<Folder> ChildFolders { get; private set; }

        public Folder()
        {
            Files = new List<File>();
            ChildFolders = new List<Folder>();
        }
    }
}
