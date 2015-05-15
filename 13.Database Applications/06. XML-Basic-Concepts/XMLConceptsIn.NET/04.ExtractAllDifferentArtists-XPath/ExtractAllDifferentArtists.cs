namespace _04.ExtractAllDifferentArtists_XPath
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    class ExtractAllDifferentArtists
    {
        private const string XmlCatalogueFilePath = "../../../albums-catalogue.xml";

        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Extracting all different artists found in 'catalogue.xml' file (XPath)***");
            Console.Write(decorationLine);

            IDictionary<string, int> artists = GetArtistsAlbumsCount();

            foreach (var artist in artists)
            {
                Console.WriteLine("Artist -> {0}, Count: {1}", artist.Key, artist.Value);
            }
        }

        private static IDictionary<string, int> GetArtistsAlbumsCount()
        {
            XmlDocument catalogueDocument = new XmlDocument();
            catalogueDocument.Load(XmlCatalogueFilePath);

            var catalogueNode = catalogueDocument.SelectNodes("/catalogue/album");

            IDictionary<string, int> artistsAlbumsCount = new Dictionary<string, int>();
            foreach (XmlNode album in catalogueNode)
            {
                string artist = album["artist"].InnerText;
                if (artistsAlbumsCount.ContainsKey(artist))
                {
                    artistsAlbumsCount[artist]++;
                }
                else
                {
                    artistsAlbumsCount[artist] = 1;
                }
            }

            return artistsAlbumsCount;
        }
    }
}
