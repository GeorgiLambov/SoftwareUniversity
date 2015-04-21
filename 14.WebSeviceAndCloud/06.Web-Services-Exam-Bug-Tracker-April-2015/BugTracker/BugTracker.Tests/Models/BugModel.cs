namespace BugTracker.Tests.Models
{
    using System;

    using BugTracker.Data.Models;

    public class BugModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public BugStatus Status { get; set; }

        public string Author { get; set; }

        public DateTime DateCreated { get; set; }

        public CommentModel[] Comments { get; set; }
    }
}
