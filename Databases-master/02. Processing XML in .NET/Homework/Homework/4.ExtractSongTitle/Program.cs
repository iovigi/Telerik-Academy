namespace ExtractSongTitle
{
    using System;
    using System.Xml;

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
