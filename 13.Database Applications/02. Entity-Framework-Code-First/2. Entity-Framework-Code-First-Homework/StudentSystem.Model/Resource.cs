namespace StudentSystem.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Resource
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(1)]
        public string Name { get; set; }
        public string Link { get; set; }
        public ResourceType ResourceType { get; set; }
        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
