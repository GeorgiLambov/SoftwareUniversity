namespace BlogSystem.Models
{
    using System.Collections.Generic;

    public class Tag
    {
        public Tag()
        {
            this.Posts = new HashSet<Post>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
