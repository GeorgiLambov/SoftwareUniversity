namespace BugTracker.RestServices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class BugDetailsModel
    {
        public BugDetailsModel()
        {
            this.Comments = new List<CommentBindingModel>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public BugStatus Status { get; set; }

        public string Author { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public IList<CommentBindingModel> Comments { get; set; }
    }
}