namespace BugTracker.Tests.Models
{
    using System;

    public class CommentModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string Author { get; set; }

        public DateTime DateCreated { get; set; }

        public int BugId { get; set; }
        
        public string BugTitle { get; set; }
    }
}
