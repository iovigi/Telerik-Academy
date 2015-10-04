namespace _9.DirectoryStructureX
{
    using System.IO;
    using System.Xml.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var rootlElement = TraverseDirectory("D:\\htdocs");

            rootlElement.Save("directory.xml");
        }

        public static XElement TraverseDirectory(string directory)
        {
            XElement element = new XElement("dir", new XAttribute("path", directory));

            foreach (var subDir in Directory.GetDirectories(directory))
            {
                element.Add(TraverseDirectory(subDir));
            }

            foreach (var file in Directory.GetFiles(directory))
            {
                XElement fileElement = new XElement("file", new XAttribute("filename", file));

                element.Add(fileElement);
            }

            return element;
        }
    }
}
