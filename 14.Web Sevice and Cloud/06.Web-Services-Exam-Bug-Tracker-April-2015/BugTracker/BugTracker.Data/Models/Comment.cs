namespace BugTracker.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Text { get; set; }

        public User Author { get; set; }

        public DateTime PublishDate { get; set; }

        public virtual Bug Bug { get; set; }

        public int BugId { get; set; }
    }
}
