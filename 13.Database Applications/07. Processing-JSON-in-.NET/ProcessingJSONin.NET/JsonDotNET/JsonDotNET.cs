namespace JsonDotNET
{
    using System;
    using Newtonsoft.Json;
    using System.Linq;

    using Helpers;

    public class JsonDotNET
    {
        static void Main()
        {
            //Create output folder
            Utility.CreateOutputFolder();

            // Problem 1.Download the content of the SoftUni RSS feed
            DownloadSoftUniRss.DownloadFile(Utility.RemoteUri, Utility.XmlFilePath);
            Console.WriteLine("Download the content of the SoftUni RSS feed is DONE!");

            // Problem 2.Parse the XML from the feed to JSON
            var json = XmLtoJson.ConvertToJson();
            Console.WriteLine(json);

            //Problem 3.Using LINQ-to-JSON select all the question titles and print them to the console
            var questionTitles = LinqToJson.PrintQuestionTitle(json);

            //Problem 4.Parse the JSON string to POCO
            var pocos = questionTitles.Select(item => JsonConvert.DeserializeObject<JsonToPoco>(item.ToString())).ToList();

            //Problem 5.Using the parsed objects create a HTML page that lists all questions from the RSS their categories and a link to the question’s page
            PocoToHtml.MakeHtml(pocos);
        }
    }
}
