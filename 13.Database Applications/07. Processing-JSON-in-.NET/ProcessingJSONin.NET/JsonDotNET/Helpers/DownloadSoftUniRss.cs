namespace JsonDotNET.Helpers
{
    using System;
    using System.IO;
    using System.Net;

    public static class DownloadSoftUniRss
    {
        public static void DownloadFile(string url, string filePath)
        {
            try
            {
                WebClient myWebClient = new WebClient();
                myWebClient.DownloadFile(url, filePath);
            }
            catch (Exception)
            {

                throw new FileNotFoundException();
            }
        }
    }
}
