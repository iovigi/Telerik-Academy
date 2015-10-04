namespace _7.CreateAlbum
{
    using System.Xml;

    class Program
    {
        static void Main(string[] args)
        {
            using (XmlReader reader = XmlReader.Create("..\\..\\..\\catalog.xml"))
            {
                using (XmlWriter writer = XmlWriter.Create("..\\..\\..\\album.xml"))
                {
                    writer.WriteStartElement("albums");
                    reader.ReadStartElement("albums");
                    while (reader.Read())
                    {
                        if (reader.Name == "album")
                        {
                            if (reader.IsStartElement())
                            {
                                writer.WriteStartElement("album");
                            }
                            else
                            {
                                writer.WriteEndElement();
                            }
                        }

                        if (reader.Name == "name")
                        {
                            if (reader.IsStartElement())
                            {
                                writer.WriteStartElement("name");
                                writer.WriteString(reader.ReadString());
                                writer.WriteEndElement();
                            }
                        }

                        if (reader.Name == "artist")
                        {
                            if (reader.IsStartElement())
                            {
                                writer.WriteStartElement("artist");
                                writer.WriteString(reader.ReadString());
                                writer.WriteEndElement();
                            }
                        }
                    }

                    writer.WriteEndElement();
                }
            }
        }
    }
}
