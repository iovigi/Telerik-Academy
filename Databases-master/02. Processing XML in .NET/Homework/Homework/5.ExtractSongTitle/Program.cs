namespace ExtractSongTitle
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            XDocument document = XDocument.Load("..\\..\\..\\catalog.xml");
            var titles = document.Root
                .Elements()
                .Elements()
                .Where(x => x.Name == "songs")
                .Elements()
                .Where(y => y.Name == "song")
                .Elements()
                .Where(y => y.Name == "title");

            foreach (var title in titles)
            {
                Console.WriteLine(title.Value.Trim());
            }
        }
    }
}
