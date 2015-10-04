namespace _12.XslTransform
{
    using System;
    using System.Xml.Xsl;

    class Program
    {
        static void Main()
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("..\\..\\..\\catalog.xslt");
            xslt.Transform("..\\..\\..\\catalog.xml", "..\\..\\..\\catalog.html");
        }
    }
}
