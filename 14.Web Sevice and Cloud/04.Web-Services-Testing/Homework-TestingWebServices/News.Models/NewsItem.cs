namespace News.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Newtonsoft.Json;

    [JsonObject]
    public class NewsItem
    {
        [Key]
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Title sould be bigger than 2 symbols")]
        [MaxLength(100, ErrorMessage = "Title sould be smaller than 100 symbols")]
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Content sould be bigger than 2 symbols")]
        [MaxLength(1000, ErrorMessage = "Content sould be smaller than 1000 symbols")]
        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }

        [JsonProperty(PropertyName = "publishDate")]
        public DateTime? PublishDate { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
