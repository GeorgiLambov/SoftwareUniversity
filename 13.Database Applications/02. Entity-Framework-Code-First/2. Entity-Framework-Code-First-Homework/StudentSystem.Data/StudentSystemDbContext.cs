namespace StudentSystem.Data
{
    using System.Data.Entity;

    using StudentSystem.Model;

    public class StudentSystemDbContext : DbContext
    {
        // base(name-of-the-connection-string)
        public StudentSystemDbContext()
            : base("StudentSystemDB")
        {
        }

        public IDbSet<Student> Students { get; set; }
        public IDbSet<Course> Courses { get; set; }
        public IDbSet<Homework> Homeworks { get; set; }
        public IDbSet<Resource> Resoursces { get; set; }
    }
}
