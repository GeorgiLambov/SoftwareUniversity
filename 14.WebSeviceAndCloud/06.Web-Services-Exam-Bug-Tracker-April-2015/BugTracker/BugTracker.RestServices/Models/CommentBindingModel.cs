namespace BugTracker.RestServices.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;

    public class CommentBindingModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Text { get; set; }

        public User Author { get; set; }

        public DateTime DateCreated { get; set; }
    }
}