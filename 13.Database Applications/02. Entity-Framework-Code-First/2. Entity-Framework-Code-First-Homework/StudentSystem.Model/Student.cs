namespace StudentSystem.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    // If we want our table to be with
    // a different name we use the [Table()] attribute
    // [Table("TableName")]
    public class Student
    {
        private ICollection<Course> courses;
        private ICollection<Homework> homeworks;

        public Student()
        {
            this.courses = new HashSet<Course>();
            this.homeworks = new HashSet<Homework>();
        }
        // For primary key use [Key] attribute
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Student name cannot be null.")]
        [MaxLength(512)]
        public string Name { get; set; }

        // Constraint with error message
        [MaxLength(10, ErrorMessage = "Phone number length cannot exceed 10 symbols")]
        public string PhoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? Birthday { get; set; }

        public virtual ICollection<Course> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }
        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value; }
        }
    }
}
