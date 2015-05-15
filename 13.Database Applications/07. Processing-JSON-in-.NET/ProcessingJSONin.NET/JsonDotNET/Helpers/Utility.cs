namespace JsonDotNET.Helpers
{
    using System.IO;

    public static class Utility
    {
        public const string OutputPath = @"..\..\..\OutputFiles";
        public const string RemoteUri = "https://softuni.bg/Feed/News";
        public const string XmlFilePath = @"..\..\..\OutputFiles\softUniRSS.xml";
        public const string HtmlPath = @"..\..\..\OutputFiles\softUniRSS.html";

        public static void CreateOutputFolder()
        {
            if (!Directory.Exists(OutputPath))
            {
                Directory.CreateDirectory(OutputPath);
            }
        }
    }
}
