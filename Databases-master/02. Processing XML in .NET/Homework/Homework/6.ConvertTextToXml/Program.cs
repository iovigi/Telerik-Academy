namespace _6.ConvertTextToXml
{
    using System.IO;
    using System.Xml;

    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fs = new FileStream("person.txt",FileMode.Open))
            {
                StreamReader reader = new StreamReader(fs);

                XmlDocument document = new XmlDocument();

                var person = document.CreateElement("person");

                var name = document.CreateElement("name");
                name.InnerText = reader.ReadLine();
                person.AppendChild(name);

                var address = document.CreateElement("address");
                address.InnerText = reader.ReadLine();
                person.AppendChild(address);

                var phone = document.CreateElement("phone");
                phone.InnerText = reader.ReadLine();
                person.AppendChild(phone);

                document.AppendChild(person);
                
                document.Save("person.xml");
            }
        }
    }
}
