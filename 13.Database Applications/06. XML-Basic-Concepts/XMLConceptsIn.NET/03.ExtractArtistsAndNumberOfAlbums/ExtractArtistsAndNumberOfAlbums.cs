namespace ExtractArtistsAndNumberOfAlbums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;

    class ExtractArtistsAndNumberOfAlbums
    {
        private const string XmlCatalogueFilePath = "../../../albums-catalogue.xml";

        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Extracting all different artists found in 'catalogue.xml' file (DOM)***");
            Console.Write(decorationLine);

            IDictionary<string, int> artists = GetArtistsAlbumsCount();

            foreach (var artist in artists)
            {
                Console.WriteLine("Artist -> {0}, Count: {1}", artist.Key, artist.Value);
            }
        }

        private static IDictionary<string, int> GetArtistsAlbumsCount()
        {
            IDictionary<string, int> artistsAlbumsCount = new Dictionary<string, int>();
            XmlDocument catalogueDocument = new XmlDocument();
            catalogueDocument.Load(XmlCatalogueFilePath);

            XmlNode catalogueNode = catalogueDocument.DocumentElement;

            foreach (XmlNode album in catalogueNode.ChildNodes)
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
