namespace DeleteLowPriceAlbums
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Xml;

    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument document = new XmlDocument();
            document.Load("..\\..\\..\\catalog.xml");
            List<XmlElement> albumsToRemove = new List<XmlElement>();

            var root = document["albums"];

            foreach (XmlElement album in root)
            {
                foreach (XmlElement information in album)
                {
                    if (information.Name == "price")
                    {
                        double price;

                        if (!double.TryParse(information.InnerText.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out price) || price > 20)
                        {
                            albumsToRemove.Add(album);
                        }
                    }
                }
            }

            foreach (var album in albumsToRemove)
            {
                root.RemoveChild(album);
            }

            document.Save("..\\..\\..\\catalogWithLowPrice.xml");
        }
    }
}
