namespace JsonDotNET.Helpers
{
    using System;
    using Newtonsoft.Json;

    public class JsonToPoco
    {
        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("a10:updated")]
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return string.Format("<a href=\"{0}\">Question's page</a><br/><h1>{1}</h1><br/><p>{2}</p><br/><em>{3}</em>",
                this.Link,
                this.Title,
                this.Description,
                this.Date);
        }
    }
}
