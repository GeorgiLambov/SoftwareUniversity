namespace JsonDotNET.Helpers
{
    using System.Xml.Linq;
    using Newtonsoft.Json;

    public static class XmLtoJson
    {
        public static string ConvertToJson()
        {
            XDocument doc = XDocument.Load(Utility.XmlFilePath);
            var serializedPlaceFormatted = JsonConvert.SerializeObject(doc, Formatting.Indented);
            return serializedPlaceFormatted;
        }
    }
}
