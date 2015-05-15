namespace CreateAlbumXMLDocument
{
    using System;
    using System.Text;
    using System.Xml;

    public class CreateAlbumXMLDocumentUI
    {
        private const string XmlCatalogueFilePath = "../../../albums-catalogue.xml";
        private const string XmlAlbumFilePath = "../../albums.xml";

        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Creating 'albums.xml' document holding the name and artist");
            Console.WriteLine("of all albums from 'catalogue.xml'***");
            Console.Write(decorationLine);

            CreateAlbumXMLDocument();
            Console.WriteLine("Done!");

        }

        static void CreateAlbumXMLDocument()
        {
            using (XmlTextWriter writer = new XmlTextWriter(XmlAlbumFilePath, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("albums");


                using (XmlReader reader = XmlReader.Create(XmlCatalogueFilePath))
                {
                    while (reader.Read())
                    {
                        if ((reader.NodeType == XmlNodeType.Element) &&
                            (reader.Name == "album"))
                        {
                            reader.ReadToDescendant("name");
                            string name = reader.ReadInnerXml();

                            reader.ReadToNextSibling("artist");
                            string artist = reader.ReadInnerXml();

                            reader.ReadToNextSibling("producer");
                            string producer = reader.ReadInnerXml();

                            WriteAlbum(writer, name, artist, producer);
                        }
                    }
                }

                writer.WriteEndElement();

            }
        }

        static void WriteAlbum(XmlTextWriter writer, string name, string artist, string producer)
        {
            writer.WriteStartElement("album");
            writer.WriteElementString("name", name);
            writer.WriteElementString("artist", artist);
            writer.WriteElementString("producer", producer);
            writer.WriteEndElement();
        }
    }
}
