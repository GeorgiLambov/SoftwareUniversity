namespace JsonDotNET.HelperClasses
{
    using System.Net;

	public static class DownloadSoftUniRss
	{
	    public static void DounloadFile()
	    {
	        
	    }
        WebClient myWebClient = new WebClient();
        string remoteUri = "https://softuni.bg/Feed/News";
        string fileName = "../../softUniRSS.xml";

        myWebClient.DownloadFile(remoteUri, fileName);

	}
}
