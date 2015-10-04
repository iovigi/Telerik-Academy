namespace _11.GetPricesLinq
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var doc = XDocument.Load("..\\..\\..\\catalog.xml");

            var albumNames = from album in doc.Descendants("album")
                             where int.Parse(album.Element("year").Value) < 2010
                             select album.Element("price").Value;

            Console.WriteLine(string.Join(Environment.NewLine, albumNames));
        }
    }
}
