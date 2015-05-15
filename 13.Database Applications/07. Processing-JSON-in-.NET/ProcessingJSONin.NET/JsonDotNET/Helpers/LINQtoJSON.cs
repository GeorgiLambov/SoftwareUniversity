namespace JsonDotNET.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json.Linq;

    public static class LinqToJson
    {
        public static List<JToken> PrintQuestionTitle(string json)
        {
            var jsonObj = JObject.Parse(json);
            var titles = jsonObj["rss"]["channel"]["item"].ToList();

            foreach (var title in titles.Select(n => n["title"]))
            {
                Console.WriteLine(title);
            }

            return titles;
        }
    }
}
