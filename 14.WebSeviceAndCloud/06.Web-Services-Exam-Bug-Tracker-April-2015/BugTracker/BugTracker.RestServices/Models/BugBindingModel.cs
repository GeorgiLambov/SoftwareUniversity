namespace BugTracker.RestServices.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class BugBindingModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public BugStatus Status { get; set; }

        public string Author { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
    }
}