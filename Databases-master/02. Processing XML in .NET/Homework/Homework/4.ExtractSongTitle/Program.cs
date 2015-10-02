using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ExtractSongTitle
{
    class Program
    {
        static void Main(string[] args)
        {
            using (XmlReader reader = XmlReader.Create("..\\..\\..\\catalog.xml"))
            {
                reader.ReadStartElement("albums");
                while (reader.Read())
                {
                    
                    if (reader.IsStartElement() && reader.Name == "title")
                    {
                        Console.WriteLine(reader.ReadString().Trim());
                    }
                }
            }
        }
    }
}
