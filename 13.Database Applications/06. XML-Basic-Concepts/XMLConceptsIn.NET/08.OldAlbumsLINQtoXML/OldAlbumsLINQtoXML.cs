namespace OldAlbumsLINQtoXML
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    class OldAlbumsLINQtoXML
    {
        private const string XmlCatalogueFilePath = "../../../albums-catalogue.xml";

        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Extracting all album prices from 'albums-catalogue.xml'");
            Console.WriteLine("published 5 years ago or earlier (LINQ to XML)***");
            Console.Write(decorationLine);


            XElement catalog = XElement.Load(XmlCatalogueFilePath);

            IEnumerable<XElement> albums =
                        from album in catalog.Elements("album")
                        where int.Parse(album.Element("year").Value) < (DateTime.Now.Year - 5)
                        select album;

            foreach (var album in albums)
            {
                Console.WriteLine("{0} -> {1:c}",
                    album.Element("name").Value, album.Element("price").Value);
            }
        }
    }
}
