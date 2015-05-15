namespace StudentSystem.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Homework
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(1)]
        public string Content { get; set; }
        public DateTime? DeadLine { get; set; }
        public ContentType ContentType { get; set; }
        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
