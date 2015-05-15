namespace _06.OldAlbums
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    class OldAlbums
    {
        private const string XmlCatalogueFilePath = "../../../albums-catalogue.xml";

        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Extracting the titles and prices for all albums, published 5 years ago or earlier found in 'catalogue.xml' file ***");
            Console.Write(decorationLine);

            IDictionary<string, string> artists = GetArtistsAlbumsCount();

            foreach (var artist in artists)
            {
                Console.WriteLine("Artist -> {0}, Price: {1}", artist.Key, artist.Value);
            }

        }

        private static IDictionary<string, string> GetArtistsAlbumsCount()
        {
            IDictionary<string, string> artistsAlbums = new Dictionary<string, string>();
            XmlDocument catalogueDocument = new XmlDocument();
            catalogueDocument.Load(XmlCatalogueFilePath);

            XmlNode catalogueNode = catalogueDocument.DocumentElement;

            foreach (XmlNode album in catalogueNode.ChildNodes)
            {
                string title = album["name"].InnerText;
                string price = album["price"].InnerText;
                int year = int.Parse(album["year"].InnerText);

                if (DateTime.Now.Year - year > 5)
                {
                    artistsAlbums[title] = price;
                }
            }

            return artistsAlbums;
        }
    }
}
