namespace _13.XsdSchema
{
    using System;
    using System.Xml.Linq;
    using System.Xml.Schema;

    internal class Program
    {
        private static void Main()
        {
            var schema = new XmlSchemaSet();
            schema.Add(string.Empty, "..\\..\\..\\catalog.xsd");

            XDocument doc = XDocument.Load("..\\..\\..\\catalog.xml");
            XDocument invalidDoc = XDocument.Load("..\\..\\..\\invalidCatalog.xml");

            doc.Validate(schema, (obj, ev) =>
            {
                Console.WriteLine("* {0} * {1}", "catalog.xml", ev.Message);
            });

            invalidDoc.Validate(schema, (obj, ev) =>
            {
                Console.WriteLine("* {0} * {1}", "invalidCatalog.xml", ev.Message);
            });
        }
    }
}
