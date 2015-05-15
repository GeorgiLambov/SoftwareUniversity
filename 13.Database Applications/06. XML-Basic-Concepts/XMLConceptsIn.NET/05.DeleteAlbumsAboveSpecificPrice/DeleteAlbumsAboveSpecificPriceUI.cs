namespace DeleteAlbumsAboveSpecificPrice
{
    using System;
    using System.Xml;

    class DeleteAlbumsAboveSpecificPrice
    {
        private const string XmlCatalogueFilePath = "../../../albums-catalogue.xml";
        private const string XmlCheapCatalogueFilePath = "../../cheap-albums-catalogue.xml";

        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Deleting all albums from 'catalog.xml' havin price > 20***");
            Console.Write(decorationLine);

            decimal maximalPrice = 20.0M;
            DeleteAlbums(maximalPrice);
        }

        private static void DeleteAlbums(decimal maximalPrice)
        {
            XmlDocument catalog = new XmlDocument();
            catalog.Load(XmlCatalogueFilePath);
            XmlNode catalogNode = catalog.DocumentElement;
           // Console.WriteLine("Root node: {0}", catalogNode.Name);

            XmlNodeList albums = catalogNode.ChildNodes;

            for (int i = 0; i < albums.Count; i++)
            {
                decimal albumPrice = decimal.Parse(albums[i]["price"].InnerText);
                if (albumPrice > maximalPrice)
                {
                    catalogNode.RemoveChild(albums[i]);
                    i--;
                }
            }

            catalog.Save(XmlCheapCatalogueFilePath);
        }
    }
}
