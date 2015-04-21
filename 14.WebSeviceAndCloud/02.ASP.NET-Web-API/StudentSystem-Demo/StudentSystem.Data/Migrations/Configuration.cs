namespace StudentSystem.Data.Migrations
{
    using StudentSystem.Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "StudentSystem.Data.StudentSystemDbContext";
        }

        protected override void Seed(StudentSystemDbContext context)
        {
            this.SeedCourses(context);
            this.SeedStudents(context);
        }

        private void SeedStudents(StudentSystemDbContext context)
        {
            if (context.Students.Any())
            {
                return;
            }

            context.Students.Add(new Student
            {
                FirstName = "Evlogi",
                LastName = "Hristov",
                Level = 1
            });

            context.Students.Add(new Student
            {
                FirstName = "Ivaylo",
                LastName = "Kenov",
                Level = 2,
            });

            context.Students.Add(new Student
            {
                FirstName = "Doncho",
                LastName = "Minkov",
                Level = 3
            });

            context.Students.Add(new Student
            {
                FirstName = "Nikolay",
                LastName = "Kostov",
                Level = 9999
            });
        }

        private void SeedCourses(StudentSystemDbContext context)
        {
            if (context.Courses.Any())
            {
                return;
            }

            context.Courses.Add(new Course
            {
                Name = "Seeded course",
                Description = "Initial course for testing"
            });
        }
    }
}
