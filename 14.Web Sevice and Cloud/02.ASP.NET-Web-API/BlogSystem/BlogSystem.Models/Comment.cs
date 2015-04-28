namespace BlogSystem.Models
{
    using System;

    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime? DateCreated { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int PostID { get; set; }

        public virtual Post Post { get; set; }
    }
}