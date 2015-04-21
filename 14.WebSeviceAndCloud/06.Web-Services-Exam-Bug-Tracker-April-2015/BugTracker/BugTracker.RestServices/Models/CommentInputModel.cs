namespace BugTracker.RestServices.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;

    public class CommentInputModel
    {
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Text { get; set; }
    }
}