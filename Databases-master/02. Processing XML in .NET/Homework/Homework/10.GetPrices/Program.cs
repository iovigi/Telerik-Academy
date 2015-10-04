namespace _10.GetPrices
{
    using System;
    using System.Xml;

    public class Program
    {
        public static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("..\\..\\..\\catalog.xml");
            var query = "albums/album[year<2010]/price";

            var albumNames = doc.SelectNodes(query);

            foreach (XmlNode name in albumNames)
            {
                Console.WriteLine(name.InnerText);
            }
        }
    }
}
