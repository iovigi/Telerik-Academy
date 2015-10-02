using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NumberOfAlbumsOfAuthor
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument document = new XmlDocument();
            document.Load("..\\..\\..\\catalog.xml");
            Dictionary<string, int> authors = new Dictionary<string, int>();

            var root = document["albums"];

            foreach(XmlElement album in root)
            {
                foreach(XmlElement information in album)
                {
                    if(information.Name == "artist")
                    {
                        string artist = information.InnerText;

                        int countOfAlbums = 0;
                        authors.TryGetValue(artist, out countOfAlbums);
                        authors[artist] = ++countOfAlbums;
                    }
                }
            }

            foreach(var kv in authors)
            {
                Console.WriteLine(kv.Value);
            }
        }
    }
}
