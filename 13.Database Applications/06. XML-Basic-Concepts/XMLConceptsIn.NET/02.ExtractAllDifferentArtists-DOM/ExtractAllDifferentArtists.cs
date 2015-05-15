namespace ExtractAllDifferentArtists_DOM
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using System.Xml;
    public class ExtractAllDifferentArtists
    {
        private const string XmlCatalogueFilePath = "../../../albums-catalogue.xml";

        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Extracting all different artists found in 'catalogue.xml' file (DOM)***");
            Console.Write(decorationLine);


            SortedSet<string> artists = GetArtists();
            foreach (var artist in artists)
            {
                Console.WriteLine("Artist -> {0}", artist);
            }
        }

        private static SortedSet<string> GetArtists()
        {
            SortedSet<string> artists = new SortedSet<string>();
            XmlDocument catalogueDocument = new XmlDocument();
            catalogueDocument.Load(XmlCatalogueFilePath);
            XmlNode catalogueNode = catalogueDocument.DocumentElement;

            foreach (XmlNode album in catalogueNode.ChildNodes)
            {
                var xmlElement = album[@"artist"];
                if (xmlElement != null)
                {
                    string artist = xmlElement.InnerText;
                    artists.Add(artist);
                }
            }

            return artists;
        }
    }
}
