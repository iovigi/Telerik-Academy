

namespace _8.DirectoryStructure
{
    using System.IO;
    using System.Xml;

    public class Program
    {
        public static void Main(string[] args)
        {
            XmlWriter writer = XmlWriter.Create("directory.xml");

            TraverseDirectory("D:\\", writer);
            writer.Close();
        }

        public static void TraverseDirectory(string directory, XmlWriter writer)
        {
            writer.WriteStartElement("dir");
            writer.WriteAttributeString("path", directory);

            foreach (var subDir in Directory.GetDirectories(directory))
            {
                TraverseDirectory(subDir, writer);
            }

            foreach (var file in Directory.GetFiles(directory))
            {
                writer.WriteStartElement("file");
                writer.WriteAttributeString("filename", file);
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }
    }
}
