namespace BugTracker.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Bug
    {
        public Bug()
        {
            this.Comments = new HashSet<Comment>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public BugStatus Status { get; set; }

        public User Author { get; set; }

        [Required]
        public DateTime SubmitDate { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
